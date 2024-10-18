using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Health healthComponent;
    public float maxFuel;
    public float currentFuel;
    public bool currentTurn;

    public virtual void Start()
    {
        currentFuel = maxFuel;
    }


    public virtual void ConsumeFuel(float amount)
    {
        currentFuel = Mathf.Max(currentFuel - amount, 0);
        if (currentFuel <= 0)
        {
            OutOfFuel();
        }
    }

    protected virtual void OutOfFuel()
    {
        StartCoroutine(WaitForAttack());
    }

    public  IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(5f);
        currentTurn = false;
    }
}
