using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnThisBus : MonoBehaviour
{

    // Time it takes in seconds to shrink from starting scale to target scale.
    public float ShrinkDuration = 5f;

    // The target scale
    public Vector3 TargetScale = Vector3.one * .5f;

    // The starting scale
    Vector3 startScale;

    public bool startShrinking = false;

    // T is our interpolant for our linear interpolation.
    float t = 0;

    void Start()
    {
        // initialize stuff in OnEnable
        startScale = transform.localScale;
        t = 0;

        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
        if(startShrinking)
        {
            // Divide deltaTime by the duration to stretch out the time it takes for t to go from 0 to 1.
            t += Time.deltaTime / ShrinkDuration;

            // Lerp wants the third parameter to go from 0 to 1 over time. 't' will do that for us.
            Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);
            transform.localScale = newScale;

            // We're done! We can disable this component to save resources.
            if (t > 1)
            {
                Destroy(this.gameObject);
                enabled = false;
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        //After we have waited 5 seconds print the time again.
        startShrinking = true;
    }

}
