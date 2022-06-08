using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace CloudFine.ThrowLab.Oculus
{
    public class TutorialButton : MonoBehaviour
    {

        public float threshold = .1f;
        public float deadzone = .025f;

        private bool _isPressed = true;
        private Vector3 _startPos;
        private ConfigurableJoint _joint;

        public GameObject Tutorial;

        // Start is called before the first frame update
        void Start()
        {
            _startPos = transform.localPosition;
            _joint = GetComponent<ConfigurableJoint>();
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.localPosition.y < -0.0201f || transform.localPosition.y > 0.05f)
            {
                GetComponent<Collider>().enabled = false;
                Pressed();
            }
            if (transform.localPosition.y >= 0 && transform.localPosition.y < 0.05f)
            {
                GetComponent<Collider>().enabled = true;
                _isPressed = true;
            }
        }

        private void Pressed()
        {
            if (_isPressed)
                Tutorial.GetComponent<TutorialScript>().IncreaseSlide();
            _isPressed = false;
        }
    }

}
