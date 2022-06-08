using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 100;
    [SerializeField] private bool _broken;

    public int speed = 5;

    public Vector3 Additional;

    void OnTriggerEnter(Collider other)
    {
        if (_broken) return;
        if (other.tag == "Weapon")
        {

            switchout(other);
            
        }
            
    }

    public void switchout(Collider other)
    {
        other.gameObject.AddComponent<Explosion>();
        speed = 0;
        _broken = true;
        Destroy(gameObject);
        var replacement = Instantiate(_replacement, transform.position + Additional, transform.rotation);

        var rbs = replacement.GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.AddExplosionForce(other.GetComponent<Collision>().relativeVelocity.magnitude * _collisionMultiplier, GetComponent<Collision>().contacts[0].point, 2);
        }
    }

    void Update()
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

}
