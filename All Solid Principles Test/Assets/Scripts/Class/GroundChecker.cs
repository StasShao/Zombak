using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    protected GroundCheckerNS _groundCheckerNS;
    [SerializeField] protected Transform _movetargetForRayPoint;
    [SerializeField]protected Transform _rayPoint;
    [SerializeField] protected RaySettings _raySattings;
    [SerializeField] protected RegdollAnimate _regdollAnimate;

    void Start()
    {
        _groundCheckerNS = new GroundCheckerNS(_rayPoint, _raySattings, _regdollAnimate, _movetargetForRayPoint);
    }

    
    void Update()
    {
        _groundCheckerNS.Tick();
    }
}
