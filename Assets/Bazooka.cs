using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudFine.ThrowLab.Oculus
{
    public class Bazooka : MonoBehaviour
    {

        public float firedelay;

        public KaisGrabbable bazooka;

        public GunfireController RocketLauncher;

        public GameObject missile;

        public GameObject Tube;

        public bool MissileLoaded = true;

        public Vector3 infront;

        public Vector3 rotation;

        // Start is called before the first frame update
        void Start()
        {
            bazooka = this.gameObject.GetComponent<KaisGrabbable>();
            //missile.transform.localScale = missile.transform.localScale / 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (bazooka.GettingGrabbed == true)
            {
                if(MissileLoaded)
                {
                    if (OVRInput.Get(OVRInput.Button.One))
                    {
                        RocketLauncher.FireWeapon();
                        StartCoroutine(FireMissile());
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
