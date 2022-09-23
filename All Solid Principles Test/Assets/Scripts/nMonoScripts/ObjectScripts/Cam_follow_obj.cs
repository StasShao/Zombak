using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_follow_obj : CamFollow
{
    [SerializeField]private Vector3 _offset;
    [SerializeField][Range(0.0f,100.0f)]private float _moveTime;
    protected override void CamFollowing()
    {
        _cam.transform.position = Vector3.Slerp(_cam.transform.position, _taget.transform.position,_moveTime) + _offset;
        _cam.transform.LookAt(_taget.transform.position);
    }

}
