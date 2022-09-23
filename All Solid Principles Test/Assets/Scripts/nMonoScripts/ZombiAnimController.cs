using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiAnimController : AnimatedController
{
    private float m;
    protected float t;
    protected override void InputListener()
    {
        m = Input.GetAxis("Vertical");
        t = Input.GetAxis("Horizontal");
        Move(m);
        Turn(t);
        if(Input.GetMouseButtonDown(0))
        {
            Punch(true);
        }
    }

    protected override void AIinput()
    {
        
    }
}
