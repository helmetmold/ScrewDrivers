using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudFine.ThrowLab.Oculus
{
    public class LoadBazooka : MonoBehaviour
    {
        public GameObject Bazooka;

        public bool inside = false;

        private GameObject Missile;

        void OnTriggerEnter(Collider col)
        {
            print("enter");
            //Check for a match with the specified name on any GameObject that collides with your GameObject
            if (col.tag == "Rocket")
            {
                inside = true;
                Missile = col.gameObject;
            }
        }

        private void Update()
        {
            if(inside)
            {
                if (Missile.GetComponent<ThrowLabOVRGrabbable>().GettingGrabbed == true)
                {
                    Bazooka.GetComponent<Outline>().enabled = true;
                }
                if (Missile.GetComponent<ThrowLabOVRGrabbable>().GettingGrabbed == false)
                {
                    Bazooka.GetComponent<GunfireController>().loaded = true;
                    Bazooka.GetComponent<Outline>().enabled = false;
                    Bazooka.GetComponent<Bazooka>().MissileLoaded = true;
                    Destroy(Missile);
                    Missile = null;
                }
            }
        }



        private void OnTriggerExit(Collider col)
        {
            if (col.tag == "Rocket")
            {
                inside = false;
                if (col.GetComponent<ThrowLabOVRGrabbable>().GettingGrabbed == true)
                {
                    Bazooka.GetComponent<Outline>().enabled = false;
                }
            }
             
        }

    }
}

