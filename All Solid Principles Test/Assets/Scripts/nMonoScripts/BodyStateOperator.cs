using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyStateOperator : MonoBehaviour,IHealth
{
    [SerializeField][Range(0.0f,5000.0f)] private float Health;
    private Animator _anim;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
       
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0.0f)
        {
            _anim.enabled = false;
        }
    }
}
