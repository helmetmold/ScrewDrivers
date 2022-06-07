using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialButton : MonoBehaviour
{

    public float threshold = .1f;
    public float deadzone = .025f;

    private bool _isPressed;
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
        if (transform.localPosition.y < -0.0201f)
        {
            GetComponent<Collider>().enabled = false;
        }

        if (!_isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (!_isPressed && GetValue() - threshold <= 1)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadzone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        print("Press");
        Tutorial.GetComponent<TutorialScript>().IncreaseSlide();
    }

    private void Released()
    {
        _isPressed = false;
        print("Released");
    }
}
