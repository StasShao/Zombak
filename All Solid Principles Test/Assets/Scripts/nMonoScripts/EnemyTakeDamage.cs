using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : TakeHit
{
    protected override void TakeDamage()
    {
        Hp -= Damage;
    }
}
