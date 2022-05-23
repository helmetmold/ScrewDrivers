using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudFine.ThrowLab.Oculus
{
    public class Bazooka : MonoBehaviour
    {

        public float firedelay;

        public GameObject bazooka;

        public GunfireController RocketLauncher;

        public GameObject missile;

        public GameObject Tube;

        public GameObject LoadBazooka;

        public bool MissileLoaded = true;

        public Vector3 infront;

        public Vector3 rotation;

        public GameObject projectileToDisableOnFire;

        // Start is called before the first frame update
        void Start()
        {
            //missile.transform.localScale = missile.transform.localScale / 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (bazooka.GetComponent<KaisGrabbable>().GettingGrabbed == true)
            {
                if(MissileLoaded)
                {
                    if (OVRInput.Get(OVRInput.Button.One))
                    {
                        RocketLauncher.FireWeapon();
                        StartCoroutine(FireMissile());
                        LoadBazooka.GetComponent<LoadBazooka>().inside = false;
                        projectileToDisableOnFire.SetActive(false);
                    }
                }
                
            }
        }

        IEnumerator FireMissile()
        {
            MissileLoaded = false;
            yield return new WaitForSeconds(firedelay);
        }

    }
}
