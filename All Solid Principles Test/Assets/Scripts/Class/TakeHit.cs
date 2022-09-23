using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TakeHit : MonoBehaviour
{
    [SerializeField] protected float Hp;
    [SerializeField] protected float Damage;
    
    void Start()
    {
        EventManager.Takehit += TakeDamage;
    }

    
    void Update()
    {
       
    }
    protected abstract void TakeDamage();
    
}
