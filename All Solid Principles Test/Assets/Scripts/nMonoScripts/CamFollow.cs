using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CamFollow : MonoBehaviour
{
   [SerializeField]protected GameObject _cam;
   [SerializeField]protected Transform _taget;

   protected abstract void CamFollowing();

   void LateUpdate()
   {
    CamFollowing();
   }

}
