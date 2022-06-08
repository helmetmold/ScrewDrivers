using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudFine.ThrowLab
{
    public class DestroyBrick : MonoBehaviour
    {

        public Material Skybox;

        public float flashspeed = 2;

        public float flashtime = 6;


        public string destroy = "Weapon";

        public GameObject ControlLives;
        // Start is called before the first frame update
        void Start()
        {


        }


        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == destroy)
            {
                Destroy(col.gameObject);

                ControlLives.GetComponent<ControlLives>().LivesLost();

            }


        }


    }
}



