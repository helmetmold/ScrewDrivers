using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeGrenade : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private float _explosionForce = 5;
    [SerializeField] private GameObject _particles;



    public void explode()
    {

        var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);



        foreach (var obj in surroundingObjects)
        {
            
            var rb = obj.GetComponent<Rigidbody>();
            if (rb == null) continue;

            //_explosionForce = other.GetComponent<Rigidbody>().velocity.z;
            //_explosionRadius = other.GetComponent<Rigidbody>().velocity.z;

            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 1);

            if (obj.GetComponent<Breakable>() != null)
            {
                obj.GetComponent<Breakable>().switchout(this.GetComponent<Collider>());
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
         //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
         Gizmos.DrawSphere(transform.position, _explosionRadius);
    }
}

