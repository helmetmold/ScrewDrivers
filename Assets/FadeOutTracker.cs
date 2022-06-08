using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutTracker : MonoBehaviour
{
    public LineRenderer line;

    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            StartCoroutine(FadeLineRenderer());
        }
    }
    IEnumerator FadeLineRenderer()
    {
        Gradient lineRendererGradient = new Gradient();
        float fadeSpeed = 3f;
        float timeElapsed = 0f;
        float alpha = 1f;

        while (timeElapsed < fadeSpeed)
        {
            alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeSpeed);

            lineRendererGradient.SetKeys
            (
                line.colorGradient.colorKeys,
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 1f) }
            );
            line.colorGradient = lineRendererGradient;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
