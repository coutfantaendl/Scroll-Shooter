using System;
using System.Collections;
using UnityEngine;

public class MeleeEnemy : EnemyBase, IAttack
{
    public void Attack()
    {
        throw new NotImplementedException();
    }

    protected override void EnterAttackState()
    {
        StopMoving();
    }
}
