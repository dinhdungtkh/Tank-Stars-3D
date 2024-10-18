using UnityEngine;
using UnityEngine.AI;
using UniRx;

public class EnemyBasic : MonoBehaviour
{
    #region Variables
    private enum State { Idle, Pursuing, Attacking }
    [SerializeField]
    private State currentState = State.Idle;

    public EnemyConfig enemyConfig;
    private Transform player;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    private float currentHealth;
    private Vector3 patrolPoint;
    private const float patrolWaitTime = 2f;
    public float patrolTimer;

    #endregion

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        currentHealth = enemyConfig.health;

        SetNewPatrolPoint();

        UniRx.Observable.EveryUpdate()
            .Subscribe(_ => UpdateEnemyBehavior())
            .AddTo(this);
    }

    private void UpdateEnemyBehavior()
    {
        switch (currentState)
        {
            case State.Idle:
                Patrol();
                if (CanSeePlayer())
                {
                    currentState = State.Pursuing;
                }
                break;

            case State.Pursuing:
                MoveTowardsPlayer();
                if (Vector3.Distance(transform.position, player.position) <= enemyConfig.attackRange)
                {
                    currentState = State.Attacking;
                }
                else if (!CanSeePlayer())
                {
                    currentState = State.Idle;
                }
                break;

            case State.Attacking:
                AttackPlayer();
                if (Vector3.Distance(transform.position, player.position) > enemyConfig.attackRange)
                {
                    currentState = State.Pursuing;
                }
                break;
        }
    }

    private void Patrol()
    {
        if (IsFinishedMoving())
        {
            patrolTimer += Time.deltaTime;
            if (patrolTimer >= patrolWaitTime)
            {
                SetNewPatrolPoint();
                patrolTimer = 0f;
            }
        }
        else
        {
            navMeshAgent.SetDestination(patrolPoint);
        }
    }

    private void SetNewPatrolPoint()
    {
        patrolPoint = transform.position + Random.insideUnitSphere * enemyConfig.patrolRadius;
        patrolPoint.y = transform.position.y; // Keep the y position constant
        navMeshAgent.SetDestination(patrolPoint);
    }

    private void MoveTowardsPlayer()
    {
        if (navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    private bool IsFinishedMoving()
    {
        // Check if the NavMeshAgent has reached its destination
        return !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance;
    }

    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        if (directionToPlayer.magnitude <= enemyConfig.detectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, enemyConfig.detectionRange))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void AttackPlayer()
    {
        Debug.Log($"Attacking player for {enemyConfig.damage} damage!");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy has died!");
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyConfig.detectionRange);
        Gizmos.DrawWireSphere(transform.position, enemyConfig.patrolRadius);
    }
}