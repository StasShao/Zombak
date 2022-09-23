using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegdollAnimate : MonoBehaviour, IPhysicHitReact
{
    private RegdollAnimateNS _regDollAnimateNS;
    [SerializeField] protected Animator _anim;
    [SerializeField]private Transform[] _targets;
    [SerializeField]private Transform[] _targetsScanRotation;
    private ConfigurableJoint[] _joints;
    private Quaternion[] _qs;

    public bool ISHIT { get; private set; }

    public void Hit(bool isHt)
    {
        ISHIT = isHt;
    }

    void Awake()
    {
        _regDollAnimateNS = new RegdollAnimateNS(_targets,_joints,_qs,_targetsScanRotation,this, _anim);
    }
    public void FallAnimate(bool _on_off)
    {
        _regDollAnimateNS.FallingAnimationPlay(_on_off);
    }
    
    void FixedUpdate()
    {
        _regDollAnimateNS.Tick();
    }
}
