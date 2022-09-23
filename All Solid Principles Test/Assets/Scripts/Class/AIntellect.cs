using UnityEngine;
using UnityEngine.AI;

public class AIntellect : MonoBehaviour, IAi
{
    private Ai_NS _ai_NS;
    private NavMeshAgent _navMeshAgent;
    [SerializeField]protected Transform _zombakRegTransform;
    [SerializeField]protected Transform _navTransfom;
    [SerializeField]protected Transform _navTarget;
    [SerializeField]protected Transform _pivot;
    [SerializeField]protected Transform _rayStartPoint;
    [SerializeField]protected Transform _refPointTransform;
    [SerializeField]protected Animator _rayAnimator;
    [SerializeField] protected Animator _zombakAnim;
    [SerializeField]protected RaySettings _raySettings;

    public bool ISMOVE { get; private set; }

    public float RAYDIST { get; private set; }

    void Awake()
    {
        _ai_NS = new Ai_NS(_navMeshAgent, _zombakRegTransform, _navTransfom, _navTarget, _pivot, _refPointTransform, _rayStartPoint, _rayAnimator, _zombakAnim, _raySettings);
    }

    private void FixedUpdate()
    {
        _ai_NS.FixTick();
    }

    void Update()
    {
        _ai_NS.Tick();
    }

    public void RayDistCount(float rayDist)
    {
        RAYDIST = rayDist;
    }

    public void Move(bool isMove)
    {
        ISMOVE = isMove;
    }
}
