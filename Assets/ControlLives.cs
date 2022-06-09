using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CloudFine.ThrowLab
{
    public class ControlLives : MonoBehaviour
    {

        public GameObject gm;

        private LivesManager lm;

        public GameObject light;

        public GameObject Greenlight;

        public GameObject[] BusesLeft;

        public GameObject GameOverScreen;

        public GameObject Wavespawner;

        public GameObject changetext;

        // Start is called before the first frame update
        void Start()
        {
            lm = gm.GetComponent<LivesManager>();
        }

        public void NewRound()
        {
            StartCoroutine(SpriteFade(Greenlight.GetComponent<Light>(), 3, 1));
            StartCoroutine(SpriteFade(Greenlight.GetComponent<Light>(), 0, 1));
        }

        public void LivesLost()
        {
            lm.lives--;
            changetext.GetComponent<ChangeText>().changeLives(lm.lives);
            if (lm.lives == 2)
            {
                StartCoroutine(SpriteFade(light.GetComponent<Light>(), 1, 1));
            }
            else if (lm.lives == 1)
            {
                StartCoroutine(SpriteFade(light.GetComponent<Light>(), 3, 1));
            }
            else if (lm.lives <= 0)
            {
                Wavespawner.GetComponent<WaveSpawner>().gameOver = true;
                /*BusesLeft = GameObject.FindGameObjectsWithTag("Vehicle");
                foreach (var bus in BusesLeft)
                {
                    bus.GetComponent<Breakable>().speed = 0;
                }
                */
                GameOverScreen.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator SpriteFade(
         Light light,
         float endValue,
         float duration)
        {
            float elapsedTime = 0;
            float startValue = light.intensity;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
                light.intensity = newAlpha;
                yield return null;
            }
        }
    }
}

