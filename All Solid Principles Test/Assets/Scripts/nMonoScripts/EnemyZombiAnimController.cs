using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZombiAnimController : AnimatedController
{
    private float m;
    private float t;
    [SerializeField] private ConfigurableJoint _conJoint;
    [SerializeField] private Transform _rayPosition;
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] [Range(0.0f, 50.0f)] private float _maxDistance;
    [SerializeField]private Color _rayColor;
    [SerializeField] private LayerMask _rayMask;

    protected override void AIinput()
    {        
            Ray ray = new Ray(_rayPosition.position, _rayPosition.forward * 100.0f);
            Debug.DrawRay(ray.origin, ray.direction * 100.0f, _rayColor);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f,_rayMask))
            {
               _rayPosition.LookAt(hit.point);
              _conJoint.targetRotation = Quaternion.Inverse(_rayPosition.rotation);
            
              
            }
    }

    protected override void InputListener()
    {
      
        Move(m);
        Turn(t);
    }
   
    
}
