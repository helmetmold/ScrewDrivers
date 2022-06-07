using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudFine.ThrowLab.Oculus
{
    public class StartGrenade : MonoBehaviour
    {
        private ThrowLabOVRGrabbable Nade;

        public GameObject BlowUp;

        // Start is called before the first frame update
        void Start()
        {
            Nade = GetComponent<ThrowLabOVRGrabbable>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Nade.GettingGrabbed)
            {
                BlowUp.GetComponent<BlowUp>().PinPulled = true;
            }
        }
    }
}

