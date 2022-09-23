using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontroller : Controller
{
    [SerializeField] private Transform _ray_position;
    [SerializeField] private Transform _charRayPlace;
    [SerializeField][Range(0.0f,100.0f)] private float _rayDistance;
    [SerializeField] private Color _rayColor;
    [SerializeField] private LayerMask _rayMask;
    [SerializeField][Range(-360.0f,360.0f)] private float _offSetHead;
    private float _walk;
    private float _rot;
    [SerializeField]private float _dist;

    private bool _rotationEnable;
    private bool _rayScan;

    
    protected override void InputListener()
    {
        EnemyRotation(_rotationEnable);
         AnimChangeFloat(_walk);
         TurnAnimChangeFloat(_rot);
         _walk = Mathf.Clamp(_walk,0.0f,1.0f);
        RayScan(_rayScan);
        _rayScan = true;

    }
    private void EnemyRotation(bool enabled)
    {
       if(enabled)
       {
          _rot += 0.8f * Time.deltaTime;
       }
        
    }
    private void RayScan(bool enabled)
    {
        
        if(enabled)
        {
            Ray ray = new Ray(_ray_position.transform.position, _ray_position.transform.forward * _rayDistance);
        Debug.DrawRay(ray.origin, ray.direction * _rayDistance, _rayColor);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,_rayDistance,_rayMask))
        {
            Transform pl = hit.transform;
            _dist = Vector3.Distance(pl.position,gameObject.transform.position);
          _ray_position.LookAt(pl.gameObject.transform.position);
          if(_dist > 1.0f)
          {
              _walk  += 0.8f *Time.deltaTime;
              AnimAttack(false);
          }
          if(_dist< 1.0f)
          {
            AnimAttack(true);
            _walk = 0.0f;
          }
        
        }else
        {
            _walk -= 0.8f * Time.deltaTime;

        }
        //================================================================
        Ray rayB = new Ray(_charRayPlace.transform.position, _charRayPlace.transform.forward * _rayDistance);
        Debug.DrawRay(rayB.origin, rayB.direction * _rayDistance, _rayColor);
        RaycastHit hitB;
        if(Physics.Raycast(rayB,out hitB,_rayDistance,_rayMask))
        {
            _rot = 0.0f;
            _rotationEnable = false;
            Transform pl = hitB.transform;
            _ray_position.localRotation = Quaternion.Euler(0,0,0);
            _ray_position.LookAt(pl.gameObject.transform.position);
        }
         else
         {
            _rotationEnable = true;
         }
  
        }

    }
}
