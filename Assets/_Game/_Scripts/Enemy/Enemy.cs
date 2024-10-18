using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UniRx;

public class Enemy : Character
{
    public EnemyConfig enemyConfig;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Camera enemyCamera;
    [SerializeField]
    private Health enemyHealth;
    public float fieldOfViewAngle = 110f;
    public float visionDistance = 30f;
    private float scanRange = 5f;
    private Coroutine scanCoroutine;
    private Coroutine fuelConsumptionCoroutine;

    private enum State { Idle, Scanning, Pursuing, Attacking, OutOfFuel }
    [SerializeField]
    private State currentState = State.Idle;

    public override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;

      
       

        if (enemyConfig != null)
        {
            enemyHealth.health = enemyConfig.health;
            currentFuel = enemyConfig.maxFuel;
            navMeshAgent.speed = enemyConfig.speed;
          
        }
       
        navMeshAgent.ResetPath();
        navMeshAgent.enabled = false;

        Observable.EveryUpdate()
            .Subscribe(_ => EnemyBehaviorPerFrame())
            .AddTo(this);
    }

    private void UpdateEnemyBehavior()
    {
        if (!currentTurn) return;

        switch (currentState)
        {
            case State.Idle:
                if (CanSeePlayerWithCamera())
                {
                    currentState = State.Pursuing;
                }
                else
                {
                    currentState = State.Scanning;
                }
                break;

            case State.Scanning:
                if (scanCoroutine == null)
                {
                    scanCoroutine = StartCoroutine(ScanForPlayer());
                }
                break;

            case State.Pursuing:
                ChasePlayer();
                if (Vector3.Distance(transform.position, player.position) <= enemyConfig.attackRange)
                {
                    currentState = State.Attacking;
                }
                break;

            case State.Attacking:
                AttackPlayer();
                break;

            case State.OutOfFuel:
                StartCoroutine(WaitForAttack());
                break;
        }
    }

    private void EnemyBehaviorPerFrame()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
      
        float distance = distanceToPlayer.magnitude;
        float fuelConsumption = distance * enemyConfig.fuelConsumptionRate * Time.deltaTime;
        
        if (currentTurn)
        {
                currentFuel = maxFuel;
                navMeshAgent.enabled = true;
                navMeshAgent.SetDestination(player.position);
                ConsumeFuel(maxFuel - distance);
                if (CanSeePlayerWithCamera()) {
                Debug.Log("OKOK");
            }
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    private void ChasePlayer()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        float distance = distanceToPlayer.magnitude;
        float fuelConsumption = distance * enemyConfig.fuelConsumptionRate * Time.deltaTime;

       

        if (currentFuel <= 0)
        {
            currentState = State.OutOfFuel;
            StopCoroutine(fuelConsumptionCoroutine);
            fuelConsumptionCoroutine = null;
            OutOfFuel();
        }
        else
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void AttackPlayer()
    {
        ConsumeFuel(enemyConfig.attackFuelCost);
        if (currentFuel <= 0)
        {
            currentState = State.OutOfFuel;
            StopCoroutine(fuelConsumptionCoroutine);
            fuelConsumptionCoroutine = null;
            OutOfFuel();
        }
        else
        {
            Debug.Log($"Attacking player for {enemyConfig.damage} damage!");
            currentTurn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) { 
            Debug.Log("Take Dame");
            //TakeDamage(10);
            enemyHealth.ReceiveDamage(10);
        }
    }


    private bool CanSeePlayerWithCamera()
    {
        Vector3 directionToPlayer = player.position - enemyCamera.transform.position;
            RaycastHit hit;
        Debug.DrawRay(enemyCamera.transform.position, directionToPlayer.normalized * visionDistance, Color.green);

        if (Physics.Raycast(enemyCamera.transform.position, directionToPlayer.normalized, out hit, visionDistance))
        {
            Debug.Log(hit.transform.tag);

            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawRay(enemyCamera.transform.position, directionToPlayer.normalized * visionDistance, Color.red);
                Debug.Log("Player detected in vision range.");
                return true;
            }
        }

        Debug.Log("Player not detected in vision range.");
        return false;
    }

    private IEnumerator ScanForPlayer()
    {
        float timer = 0f;
        while (timer < scanRange)
        {
            timer += Time.deltaTime;
            transform.Rotate(Vector3.up, 10f * Time.deltaTime);

            if (CanSeePlayerWithCamera())
            {
                currentState = State.Pursuing;
                yield break;
            }

            yield return null;
        }

        scanCoroutine = null;
        currentState = State.Idle;
    }
}