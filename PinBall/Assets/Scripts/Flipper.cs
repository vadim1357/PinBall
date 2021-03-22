using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] float restPos = 0f;
    [SerializeField] float pressedPos = 45f;
    [SerializeField] float hitStrength = 100000f;
    [SerializeField] float flipperDamper = 150f;
    [SerializeField] bool leftFlipper;

    HingeJoint hinge;
    JointSpring spring;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true; 

        spring = new JointSpring();
    }

    // Update is called once per frame
    void Update()
    {
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if (leftFlipper && Input.GetAxis("Horizontal") < 0 || !leftFlipper && Input.GetAxis("Horizontal") > 0)
        {
            spring.targetPosition = pressedPos;
        }
        else
        {
            spring.targetPosition = restPos;
        }
        hinge.spring = spring;
    }
}
