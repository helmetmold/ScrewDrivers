using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 2;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
