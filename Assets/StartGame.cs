using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CloudFine.ThrowLab.Oculus
{
    public class StartGame : MonoBehaviour
    {
        private bool _isPressed = true;

        public GameObject Tutorial;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.localPosition.y < -0.0201f)
            {
                GetComponent<Collider>().enabled = false;
                Pressed();
            }
            if (transform.localPosition.y >= 0)
            {
                GetComponent<Collider>().enabled = true;
                _isPressed = true;
            }
        }

        private void Pressed()
        {
            if (_isPressed)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            _isPressed = false;
        }
    }
}

