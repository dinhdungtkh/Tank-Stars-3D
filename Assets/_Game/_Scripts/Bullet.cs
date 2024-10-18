using ChobiAssets.KTP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Bullet settings")]
    [Tooltip("Life time of the bullet. (Sec)")] public float lifeTime = 5.0f;
    [Tooltip("Prefab for the broken effects.")] public GameObject brokenObject;
    [Tooltip("Set this Rigidbody.")] public Rigidbody thisRigidbody;


    Transform thisTransform;
    bool isLiving = true;
    bool hasDetected = false;
    Ray ray = new Ray();
    Vector3 hitPos;
    Transform hitTransform;
    Vector3 hitNormal;
    float damage = 10f;
    private void Start()
    {
        thisTransform = transform;
        if (thisRigidbody == null)
        {
            thisRigidbody = GetComponent<Rigidbody>();
        }
        Destroy(gameObject, lifeTime);
       
    }

    void FixedUpdate()
    {
        if (isLiving == false)
        { 
            return;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isLiving == false)
        { 
            return;
        }
        hitTransform = collision.collider.transform;
        Hit();
    }
    void Hit()
    {
        isLiving = false;

        if (brokenObject)
        {
            Instantiate(brokenObject, thisTransform.position, Quaternion.identity);
        }

        if (hitTransform == null)
        {
            return;
        }

        var targetDamageScript = hitTransform.root.GetComponent<Health>();
        if (targetDamageScript)
        {
            targetDamageScript.ReceiveDamage(damage);
        }
        Destroy(this.gameObject);
    }


}
