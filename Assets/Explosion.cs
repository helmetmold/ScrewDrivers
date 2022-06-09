using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 5;
    [SerializeField] private float _explosionForce = 5;
    [SerializeField] private GameObject _particles;

    private void OnCollisionEnter(Collision collision)
    {

            var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);

            foreach (var obj in surroundingObjects)
            {
                var rb = obj.GetComponent<Rigidbody>();
                if (rb == null) continue;

            _explosionForce = collision.relativeVelocity.magnitude;
            _explosionRadius = collision.rigidbody.velocity.x;

            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 1);
            }

            Destroy(gameObject);
    }
}
