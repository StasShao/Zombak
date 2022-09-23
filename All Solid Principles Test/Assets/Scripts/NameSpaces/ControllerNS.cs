using UnityEngine;

public class ControllerNS 
{
    private IController _icontroller;
    private Rigidbody _rb;
    private GameObject _character;
    private Animator _anim;
    private Transform _animlookPosition;
    public ControllerNS(Rigidbody rb, Transform animlookPosition,GameObject character)
    {
        _rb = rb;
        _character = character;
        _icontroller = _character.GetComponent<IController>();
        _anim = _character.GetComponent<Animator>();
        _animlookPosition = animlookPosition;
    }
        
    private void Mower()
    {
        if(_rb != null)
        {
            _rb.AddForce(-_rb.transform.forward * _icontroller.FORCE, ForceMode.Force);
            _rb.AddTorque(_rb.transform.up * _icontroller.TURN, ForceMode.Force);
           
        }
        if(_anim != null)
        {
            _anim.SetFloat("Walk", _icontroller.WALK_ANIM);
            _anim.SetFloat("Turn", _icontroller.TURN_ANIM);
            if(_icontroller.ATTACK)
            {
                _anim.SetTrigger("Attack");
            }
        }
    }
    private void OnAnimatorIK()
    {
        _anim.SetLookAtWeight(1);
        _anim.SetLookAtPosition(_animlookPosition.position);
    }
    public void Tick()
    {
        Mower();
        
    }
}
