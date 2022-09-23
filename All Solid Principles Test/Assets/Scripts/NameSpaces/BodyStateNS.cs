using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyStateNS 
{
    private float _health;
    private Animator _anim;
    private GameObject _gameObject;
    public BodyStateNS(float health, Animator anim, GameObject gameObject)
    {
        _gameObject = gameObject;
        _health = health;
        _anim = anim;
        anim = _gameObject.GetComponent<Animator>();
    }
   
}
