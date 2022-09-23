using UnityEngine;
using UnityEngine.AI;

//====================================================================================================================
public class RegdollAnimateNS 
{
    private Transform[] _targetsBottomBody;
    private Animator _anim;
    private Transform[] _targetsScanRotationBottomBody;
    private ConfigurableJoint[] _jointsBottomBody;
    private Quaternion[] _qsBottomBody;
    private RegdollAnimate _ragdollanimate;
    private IPhysicHitReact _iphysicsHitReact;
    private float _timer;
    private float maxClamp;
    private float maxDamperClamp;
    public RegdollAnimateNS(Transform[] targets,ConfigurableJoint[] joints,Quaternion[] qs,Transform[] targetsScanRotation, RegdollAnimate ragdollanimate, Animator anim)
  {
        _anim = anim;
        _ragdollanimate = ragdollanimate;
        _iphysicsHitReact = _ragdollanimate.GetComponent<IPhysicHitReact>();
    _targetsBottomBody = targets;
    _targetsScanRotationBottomBody = targetsScanRotation;
    _jointsBottomBody = new ConfigurableJoint[_targetsBottomBody.Length];
    _qsBottomBody = new Quaternion[_targetsBottomBody.Length];
    joints = _jointsBottomBody;
    qs = _qsBottomBody;
    for (int i = 0; i < targets.LongLength; i++)
    {
      _jointsBottomBody[i] = _targetsBottomBody[i].GetComponent<ConfigurableJoint>();
      _qsBottomBody[i] = _targetsScanRotationBottomBody[i].transform.rotation;
    }
        _iphysicsHitReact.Hit(false);
  }
  public void Tick()
  {
        PhysFallDown();
     GetRotations();
        TimerSet(_iphysicsHitReact);
  }
  private void GetRotations()
  {
      for(int i = 0; i < _targetsBottomBody.Length; i++)
      {
             _jointsBottomBody[i].targetRotation = Quaternion.Inverse(_targetsScanRotationBottomBody[i].localRotation) * _qsBottomBody[i];
      }
  }
    private void  PhysFallDown()
    {
        maxClamp = Mathf.Clamp(maxClamp, 0.0f, 50000.000f);
        maxDamperClamp = Mathf.Clamp(maxDamperClamp, 0.0f, 1000.0f);
        foreach (ConfigurableJoint item in _jointsBottomBody)
        {
            JointDrive jd = item.slerpDrive;
            jd.positionSpring = maxClamp;
            jd.positionDamper = maxDamperClamp;
            item.slerpDrive = jd;
        }

        if (_iphysicsHitReact.ISHIT)
        {

            maxClamp = 300.0f;
            maxDamperClamp = 50.0f;
        }else
        {
            maxClamp += 10000.0f * Time.deltaTime;
            maxDamperClamp += 500.0f * Time.deltaTime;
        } 
    }
    private void TimerSet(IPhysicHitReact iHit)
    {
        if (iHit.ISHIT)
        {
            _timer += 0.2f * Time.deltaTime;
            if (_timer >= 1.0f)
            {
                _timer = 0.0f;
                iHit.Hit(false);
            }
        }
    }
    public void FallingAnimationPlay(bool on_off)
    {
        _anim.SetBool("Falling", on_off);
    }
}
//====================================================================================================================
public class MainControllerNS
{
    private AnimatedController _animateController;
    private IAnimatedController _ianimController;
    private Animator _animator;
    private Transform _pivot;
    public MainControllerNS(AnimatedController animateController, Animator animator, Transform pivot)
    {
        _pivot = pivot;
        _animator = animator;
        _animateController = animateController;
        _ianimController = _animateController.GetComponent<IAnimatedController>();
    }
    public void Tick()
    {
        AnimatorListener();
    }
    private void AnimatorListener()
    {
        if(_pivot != null)
        {
            _pivot.Rotate(0, _ianimController.TURNFORCE, 0);
        }
       
        _animator.SetFloat("Walk", _ianimController.MOVEFORCE);
        _animator.SetFloat("Turn", _ianimController.TURNFORCE);
        if(_ianimController.ISPUNCH)
        {
            _animator.SetTrigger("Attack");
            _ianimController.Punch(false);
        }
    }
}
//====================================================================================================================
public class CamFollowNS
{
    private Transform _camTransform;
    private Transform _pivotTransform;
    private Transform _targetTransform;
    private CamFollowSettings _camFollowSettings;
    private Vector3 _rf;
    public CamFollowNS(Transform camTransform, Transform targetTransform, Vector3 rf, CamFollowSettings camFollowSettings, Transform pivotTransform)
    {
        _pivotTransform = pivotTransform;
        _rf = rf;
        _camFollowSettings = camFollowSettings;
        _camTransform = camTransform;
        _targetTransform = targetTransform;
    }
    public void Tick()
    {
        if(_camTransform != null)
        {
            CamLookAndFollow();
        }
      
    }
    private void CamLookAndFollow()
    {
        _pivotTransform.position = Vector3.SmoothDamp(_pivotTransform.position, _targetTransform.position, ref _rf, _camFollowSettings.CamFollowSpeed);
        _camTransform.position = Vector3.SmoothDamp(_camTransform.position, _pivotTransform.position, ref _rf, _camFollowSettings.CamFollowSpeed) + _camFollowSettings.OffSet;
        _camTransform.LookAt(_targetTransform.position);
    }
}
//==============================================================================================================================
public class PhysicalHitReationNS
{
    private IPhysicHitReact _iphysicalHitReact;
    private IgroundCheck _igroundCheck;
    private PhysicalHitReaction _physicalHitReact;
    private ConfigurableJoint[] _confJoints;
    private float _timer;
    private bool _ht;
    public PhysicalHitReationNS(PhysicalHitReaction physicalHitReact, ConfigurableJoint[] confJoints)
    {
        _confJoints = confJoints;
        _physicalHitReact = physicalHitReact;
        _iphysicalHitReact = _physicalHitReact.GetComponent<IPhysicHitReact>();
        _igroundCheck = _physicalHitReact.GetComponent<IgroundCheck>();
    }
    public void OnCollisionEnter(Collision col)
    {
      
       
    }
    
    private void Ilistener()
    {
        if(_igroundCheck != null)
        {
            if (!_igroundCheck.ISGOUNDED)
            {
                foreach (ConfigurableJoint item in _confJoints)
                {
                    JointDrive jd = item.slerpDrive;
                    jd.positionSpring = 0.0f;
                    jd.positionDamper = 0.0f;
                    item.slerpDrive = jd;
                }
            }
            else
            {
                foreach (ConfigurableJoint item in _confJoints)
                {
                    JointDrive jd = item.slerpDrive;
                    jd.positionSpring = 50000.0f;
                    jd.positionDamper = 100.0f;
                    item.slerpDrive = jd;
                }
            }
        }
        
    }
    private void TimerSet(IPhysicHitReact iHit)
    {
        if(iHit.ISHIT)
        {
            _timer += 0.2f * Time.deltaTime;
            if(_timer >= 10.0f)
            {
                _timer = 0.0f;
                iHit.Hit(false);
            }
        }
    }
    public void Tick()
    {
        
    }
}
//==============================================================================================================================
public class WeaponNS
{
    private IPhysicHitReact _iPhysicHtReact;
    private GameObject _enteringGO;
    private LayerMask _layermask;
    public WeaponNS(GameObject enteringGO, LayerMask layermask)
    {
        _enteringGO = enteringGO;
        _layermask = layermask;
    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject != _enteringGO &&  col.gameObject.layer != _layermask)
        {
            if(col.gameObject.tag == "Head"||col.gameObject.tag == "Body")
            {
               
                _enteringGO = col.gameObject;
                _iPhysicHtReact = col.gameObject.GetComponentInParent<IPhysicHitReact>();
                if (col.impulse.z > 15.0f || col.impulse.x > 15.0f || col.impulse.y > 15.0f)
                {
                    _iPhysicHtReact.Hit(true);
                    
                }
            }
          
            
        }else if(_iPhysicHtReact != null)
        {
            if(col.impulse.z > 15.0f || col.impulse.x > 15.0f || col.impulse.y > 15.0f)
            {
                _iPhysicHtReact.Hit(true);
            }
           
        }

    }
}
//==============================================================================================================================

public class Ai_NS
{
    private NavMeshAgent _navMeshAgent;
    private Transform _zombakRegTransform;
    private Transform _navTransfom;
    private Transform _navTarget;
    private Transform _pivot;
    private Transform _rayStartPoint;
    private Transform _refPointTransform;
    private Animator _rayAnimator;
    private Animator _zombakAnim;
    private RaySettings _raySettings;
    private IAi _iAi;
    private float navDist;
    public Ai_NS(NavMeshAgent navMeshAgent, Transform zombakRegTransform, Transform navTransfom, Transform navTarget, Transform pivot, Transform refPointTransform, Transform rayStartPoint, Animator rayAnimator, Animator zombakAnim, RaySettings raySettings)
    {
        _zombakRegTransform = zombakRegTransform;
        _raySettings = raySettings;
        _navTransfom = navTransfom;
        _navTarget = navTarget;
        _pivot = pivot;
        _refPointTransform = refPointTransform;
        _rayStartPoint = rayStartPoint;
        _rayAnimator = rayAnimator;
        _zombakAnim = zombakAnim;
        _iAi = _navTransfom.gameObject.GetComponent<IAi>();
        _navMeshAgent = _navTransfom.gameObject.GetComponent<NavMeshAgent>();
        _navMeshAgent.avoidancePriority = Random.Range(1, 50);
    }
    private void RayPositioning()
    {
        Ray ray = new Ray(_rayStartPoint.position, _rayStartPoint.forward * _raySettings.RayDist);
        Debug.DrawRay(ray.origin, ray.direction * _raySettings.RayDist, _raySettings.RayColor);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, _raySettings.RayDist,_raySettings.Mask))
        {
            _iAi.Move(true);
            _rayAnimator.enabled = false;
            _rayStartPoint.LookAt(hit.collider.transform);
            _navTarget = hit.collider.gameObject.transform;
            if(navDist < _raySettings.NavMaxDist)
            {
                _navMeshAgent.speed = 5.5f;
                _navMeshAgent.SetDestination(_navTarget.position);
            }
            else
            {
                _navMeshAgent.speed = 0.0f;
            }
        }
        else
        {
            _iAi.Move(false);
            _rayAnimator.enabled = true;
            if (navDist < _raySettings.NavMaxDist)
            {
                _navMeshAgent.speed = 5.5f;
                _navMeshAgent.SetDestination(_refPointTransform.position);
            }
            else
            {
                _navMeshAgent.speed = 0.0f;
            }
        }
    }
    private void RotationPivot()
    {
        Vector3 dir = (_navTransfom.position - _pivot.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        _pivot.rotation = Quaternion.Lerp(_pivot.rotation, LookRotation, Time.deltaTime * 2.0f);
    }
    private void MoveReg()
    {
        _pivot.position = _rayStartPoint.position;
        _rayStartPoint.position = _zombakRegTransform.position;
        navDist = Vector3.Distance(_rayStartPoint.position, _navTransfom.position);
        if(navDist > _raySettings.NavDist)
        {
            _zombakAnim.SetFloat("Walk", 1);
        }else 

        {
            _zombakAnim.SetFloat("Walk", 0);
        }
    }
    private void AttackReason()
    {
        if(navDist <= _raySettings.NavDist && _iAi.ISMOVE)
        {
            _zombakAnim.SetFloat("RandomChoser", Random.Range(0.0f, 1.0f));
            _zombakAnim.SetTrigger("Attack");
        }
    }
    public void FixTick()
    {
        RayPositioning();
    }
    public void Tick()
    {
        AttackReason();
        MoveReg();
        RotationPivot();
    }
}
//==============================================================================================================================
public class GroundCheckerNS
{
    private Transform _rayPoint;
    private Transform _movetargetForRayPoint;
    private RaySettings _raySattings;
    private RegdollAnimate _regdollAnimate;
    private IPhysicHitReact _IphysicHitReact;
    private float _distToground;

    public GroundCheckerNS(Transform rayPoint, RaySettings raySattings, RegdollAnimate regdollAnimate, Transform movetargetForRayPoint)
    {
        _movetargetForRayPoint = movetargetForRayPoint;
        _rayPoint = rayPoint;
        _raySattings = raySattings;
        _regdollAnimate = regdollAnimate;
        _IphysicHitReact = _regdollAnimate.GetComponent<IPhysicHitReact>();
    }
    private void GroundCheck()
    {
        _rayPoint.rotation = Quaternion.Euler(0, 0, 0);
        _rayPoint.position = _movetargetForRayPoint.position;
        Ray ray = new Ray(_rayPoint.position, -_rayPoint.up * _raySattings.RayDist);
        Debug.DrawRay(ray.origin, ray.direction * _raySattings.RayDist, _raySattings.RayColor);
        RaycastHit hit;
        
        if(!Physics.Raycast(ray,out hit,_raySattings.RayDist,_raySattings.Mask))
        {
            _IphysicHitReact.Hit(true);
        }
        else
        {
            _distToground = Vector3.Distance(_rayPoint.position, hit.point);
        }

    }
    private void InAir()
    {
        if(_distToground > 1.5f)
        {
            _regdollAnimate.FallAnimate(true);
        }else
        {
            _regdollAnimate.FallAnimate(false);
        }
    }
    public void Tick()
    {
        GroundCheck();
        InAir();
    }
}
//==============================================================================================================================

