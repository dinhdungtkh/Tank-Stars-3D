using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "ScriptableObjects/HealthData", order = 1)]
public class HealthData : ScriptableObject
{
    public float maxHealth;
    public float currentHealth;

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
