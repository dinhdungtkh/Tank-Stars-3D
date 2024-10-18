using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIBar : MonoBehaviour
{
    [SerializeField]
    private Health currentHealth;

    [SerializeField]
    private Image fill;

    private void Update()
    {
        if (currentHealth != null && fill != null)
        {
            fill.fillAmount = currentHealth.GetPercentage();
        }
    }
}