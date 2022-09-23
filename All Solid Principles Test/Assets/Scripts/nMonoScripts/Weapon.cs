using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private IHealth _ihealth;
    private Animator _animator;
    private GameObject _enteringGO;
    [SerializeField][Range(0.0f,1000.0f)]private float Damage;
    [SerializeField][Range(0.0f,1000.0f)]private float MaximumDamage;
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject != _enteringGO)
        {
            _enteringGO = col.gameObject;
            _ihealth = col.gameObject.GetComponent<IHealth>();
            _animator = col.gameObject.GetComponent<Animator>();
        }else
        if(_ihealth != null)
        {
            if(col.impulse.z > 2.0f)
            {
                 _ihealth.TakeDamage(damage: MaximumDamage);
                  if(_animator != null)
                  {
                    _animator.SetTrigger("TakeMaximumHit");
                  }
            }
             if(col.impulse.z > 0.5f&& col.impulse.z < 2.0f)
            {
                _ihealth.TakeDamage(Damage);
                 if(_animator != null)
                  {
                    _animator.SetTrigger("TakeHit");
                  }
            }
            
        }
       
    }
}
