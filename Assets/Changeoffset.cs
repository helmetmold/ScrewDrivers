using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloudFine.ThrowLab.Oculus
{
    public class Changeoffset : MonoBehaviour
    {
        bool gettingrabbed = false;

        public GameObject offset;

        Vector3 Lhand = new Vector3(.7f, 1f, 3f);
        Vector3 Rhand = new Vector3(3f, 1f, .7f);

        Quaternion Lhandrot = new Quaternion(-90f,0f,0f,0f);
        Quaternion Rhandrot = new Quaternion(90f, 0f, 0f, 0f);

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            gettingrabbed = this.GetComponent<ThrowLabOVRGrabbable>().isGrabbed;
            if(gettingrabbed)
            {
                if(this.GetComponent<ThrowLabOVRGrabbable>().grabbedBy.m_controller == OVRInput.Controller.LTouch)
                {
                    offset.transform.position = Lhand;
                    offset.transform.rotation = Lhandrot;
                }
                if (this.GetComponent<ThrowLabOVRGrabbable>().grabbedBy.m_controller == OVRInput.Controller.RTouch)
                {
                    offset.transform.position = Rhand;
                    offset.transform.rotation = Rhandrot;

                }
            }
        }
    }
}

