using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public Renderer material;

    float fadeOutTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut(fadeOutTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOut(float time)
    {
        Destroy(this);
        float index = 0.0f;
        float rate = 1.0f / time;
        while (index < 1.0f)
        {
            index -= rate;
            yield return null;
        }
        
    }

}
