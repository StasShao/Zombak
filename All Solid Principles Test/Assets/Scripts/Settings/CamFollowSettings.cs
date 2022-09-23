using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="CamFollowSettings",fileName ="CamFollowSettings/Data")]
public class CamFollowSettings : ScriptableObject
{
    [SerializeField] [Range(0.0f, 10.0f)] private float camfollowSpeed;
    [SerializeField] private Vector3 offSet;
    public float CamFollowSpeed { get { return camfollowSpeed; } }
    public Vector3 OffSet { get { return offSet; } }
}
