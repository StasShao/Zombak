using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private CamFollowNS _camFollowNS;
    [SerializeField]protected Transform _pivotTransform;
    [SerializeField]protected Transform _camTransform;
    [SerializeField]protected Transform _targetTransform;
    [SerializeField]protected Vector3 _offset;
    [SerializeField]protected CamFollowSettings _camFollowSettings;
    private void Awake()
    {
        _camFollowNS = new CamFollowNS(_camTransform, _targetTransform, _offset, _camFollowSettings, _pivotTransform);
    }
    private void LateUpdate()
    {
        _camFollowNS.Tick();
    }

}
