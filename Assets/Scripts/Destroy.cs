using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    Renderer m_Renderer;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public float speed = 5;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        print("ok");

        if (other.tag == "despawn")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Weapon")
        {
            StartCoroutine(ExampleCoroutine());
        }

        IEnumerator ExampleCoroutine()
        {

            m_Renderer.material.color = Color.red;
            speed = 0;

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(3);

            Destroy(gameObject);
        }
    }
}
