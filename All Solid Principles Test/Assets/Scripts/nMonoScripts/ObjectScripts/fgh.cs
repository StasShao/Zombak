using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fgh : Controller
{
    private float _animWalkFloat;
    private float _animTurnChange;
    private bool _attack;
    protected override void InputListener()
    {
        AnimChangeFloat(_animWalkFloat);
        TurnAnimChangeFloat(_animTurnChange);
        AnimAttack(_attack);
        _animWalkFloat = Input.GetAxis("Vertical");
        _animTurnChange = Input.GetAxis("Horizontal");
        _attack = Input.GetMouseButtonDown(0);

    }
  
  
}
