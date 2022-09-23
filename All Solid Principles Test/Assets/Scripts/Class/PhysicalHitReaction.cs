using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalHitReaction : MonoBehaviour, IPhysicHitReact, IgroundCheck
{
    private PhysicalHitReationNS _physicalHitReactNS;
    [SerializeField]protected ConfigurableJoint[] _confJoints;
     void Awake()
    {
        _physicalHitReactNS = new PhysicalHitReationNS(this, _confJoints);
    }
    void Update()
    {
        _physicalHitReactNS.Tick();
    }

    public bool ISHIT { get; protected set; }

    public bool ISGOUNDED { get; protected set; }

    public void Hit(bool isHt)
    {
        ISHIT = isHt;
    }

    private void OnCollisionEnter(Collision col)
    {
       
    }

    public void IsGrounded(bool isGrounded)
    {
        ISGOUNDED = isGrounded;
    }
}
