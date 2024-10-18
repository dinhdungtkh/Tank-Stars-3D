using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyConfig", menuName = "Enemy/Config")]
public class EnemyConfig : ScriptableObject
{
    public float health = 100f;
    public float damage = 10f;
    public float detectionRange = 50f;
    public float attackRange = 2f;
    public float speed = 5f;
    public float patrolRadius = 50f;
    public bool isMoving;
    public float patrolWaitTime = 3f;
    public float maxFuel = 100;
    public float fuelConsumptionRate = 1f;
    public float attackFuelCost = 50f;
    public float fuelConsumptionPerSecond = 1f;
}