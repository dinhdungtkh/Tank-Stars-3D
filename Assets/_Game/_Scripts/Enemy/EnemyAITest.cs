using UnityEngine;

public class EnemyAITest : Character
{
    public float detectionRadius = 15f;
    public float fireRate = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform playerTransform;
    private float nextFireTime = 0f;
    [SerializeField]
    private Camera enemyCamera;

    public override void Start()
    {
        base.Start();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (currentTurn)
        {
            CheckAndFireAtPlayer();
        }
    }

    private void CheckAndFireAtPlayer()
    {
        Vector3 directionToPlayer = playerTransform.position - enemyCamera.transform.position;
        Ray ray = new Ray(enemyCamera.transform.position, directionToPlayer);

        if (Physics.Raycast(ray, out RaycastHit hit, detectionRadius))
        {
            if (IsPartOfPlayer(hit.transform))
            {
                Debug.DrawRay(enemyCamera.transform.position, directionToPlayer, Color.green);

                if (Time.time >= nextFireTime)
                {
                    FireAtPlayer(hit.point);
                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
            else
            {
                Debug.DrawRay(enemyCamera.transform.position, directionToPlayer, Color.yellow);
            }
        }
        else
        {
            Debug.DrawRay(enemyCamera.transform.position, directionToPlayer.normalized * detectionRadius, Color.red);
        }
    }

    private bool IsPartOfPlayer(Transform hitTransform)
    {
        // Kiểm tra xem hitTransform hoặc bất kỳ parent nào của nó có phải là Player không
        while (hitTransform != null)
        {
            if (hitTransform == playerTransform)
            {
                return true;
            }
            hitTransform = hitTransform.parent;
        }
        return false;
    }

    private void FireAtPlayer(Vector3 targetPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        Vector3 launchDirection = (targetPosition - firePoint.position).normalized;
        float launchForce = 10f;
        rb.velocity = new Vector3(launchDirection.x, 1f, launchDirection.z) * launchForce;
    }
}