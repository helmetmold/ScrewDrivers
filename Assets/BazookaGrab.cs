using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudFine.ThrowLab.Oculus
{
    public class BazookaGrab : MonoBehaviour
    {
        public bool inside = false;

        public GameObject handle;

        public GameObject lefthand;
        public GameObject righthand;

        private SpringJoint springjoint;

        public GameObject connectedBody;

        public bool grabbed = false;

        void OnTriggerEnter(Collider col)
        {
            springjoint = handle.GetComponent<SpringJoint>();
            if (col.tag == "LeftHand")
            {
                inside = true;
            }
        }

        private void Update()
        {
            if (inside)
            {
                if (!grabbed)
                {
                    handle.transform.position = lefthand.transform.position;
                    handle.transform.rotation = lefthand.transform.rotation;
                }
                if(handle.GetComponent<KaisGrabbable>().GettingGrabbed)
                {
                    springjoint.connectedBody = connectedBody.GetComponent<Rigidbody>();

                    grabbed = true;
                }
                
                if (handle.GetComponent<KaisGrabbable>().GettingGrabbed == false)
                {
                    grabbed = false;
                }
            }
            else
            {
                springjoint.connectedBody = null;
            }
        }



        private void OnTriggerExit(Collider col)
        {
            if (col.tag == "LeftHand")
            {
                inside = false;
                grabbed = false;
            }

        }
    }
}

