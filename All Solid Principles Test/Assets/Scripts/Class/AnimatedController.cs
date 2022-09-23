using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimatedController : MonoBehaviour, IAnimatedController
{
    private MainControllerNS _mainControllerNS;
    private AnimatedController _animateController;
    [SerializeField] private Transform _pivot;
    [SerializeField]private Animator _animator;
    public float MOVEFORCE { get; private set; }

    public float TURNFORCE { get; private set; }

    public bool ISPUNCH { get; private set; }

    public void Move(float Mforce)
    {
        MOVEFORCE = Mforce;
    }

    public void Punch(bool isPunch)
    {
        ISPUNCH = isPunch;
    }

    public void Turn(float Tforce)
    {
        TURNFORCE = Tforce;
    }
    protected abstract void InputListener();
    protected abstract void AIinput();

    void Awake()
    {
        _mainControllerNS = new MainControllerNS(this, _animator, _pivot);
    }
    void Update()
    {
        InputListener();
       
        _mainControllerNS.Tick();
    }
    void FixedUpdate()
    {
        AIinput();
    }
}
