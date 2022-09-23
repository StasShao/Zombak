using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponPart : MonoBehaviour
{
    private WeaponNS _weaponNS;
    protected GameObject _enteringGO;
    [SerializeField]protected LayerMask _layermask;

    void Awake()
    {
        _weaponNS = new WeaponNS(_enteringGO, _layermask);
    }
    public void OnCollisionEnter(Collision col)
    {
        _weaponNS.OnCollisionEnter(col);
        
    }


}
