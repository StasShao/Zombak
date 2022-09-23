using UnityEngine;

public abstract class Controller : MonoBehaviour, IController
{
    private ControllerNS _controllerNS;
    [SerializeField] [Range(0.0f, 5000.0f)] private float _setForce;
    [SerializeField] [Range(0.0f, 5000.0f)] private float _setRotSpeed;
    [SerializeField]protected Rigidbody _rb;
    [SerializeField] protected Transform _animlookPosition;
    [SerializeField]protected GameObject _character;
    
    public float FORCE { get; private set; }

    public float TURN { get; private set; }

    public float JUMPFOCE { get; private set; }

    public float WALK_ANIM { get; private set; }

    public float TURN_ANIM { get; private set; }

    public bool ATTACK { get; private set; }

    void Awake()
    {
        _controllerNS = new ControllerNS( _rb,_animlookPosition,_character);
    }
     void Update()
    {
        _controllerNS.Tick();
        InputListener();
    }
    public void ForceChanger(float change)
    {
        FORCE = change * _setForce;
    }

    public void TurnChanger(float change)
    {
        TURN = change * _setRotSpeed;
    }
    protected abstract void InputListener();

    public void AnimChangeFloat(float animChange)
    {
        WALK_ANIM = animChange;
    }

    public void TurnAnimChangeFloat(float turnChange)
    {
        TURN_ANIM = turnChange;
    }

    public void AnimAttack(bool isattack)
    {
        ATTACK = isattack;
    }
   
}
