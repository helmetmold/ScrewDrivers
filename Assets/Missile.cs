using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public bool fired;
    public float speed = 100f;
    public Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fired)
        {
            rb.AddRelativeForce(this.transform.forward * speed, ForceMode.Impulse);
        }
    }
}
