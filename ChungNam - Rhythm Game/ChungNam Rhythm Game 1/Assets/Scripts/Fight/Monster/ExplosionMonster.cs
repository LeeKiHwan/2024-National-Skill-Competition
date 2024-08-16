using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMonster : Monster
{
    public override void Die()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 1.5f, LayerMask.GetMask("Monster"));

        foreach (Collider col in cols)
        {
            if (col.GetComponent<Monster>().positionType == PositionType.Ground)
            {
                if (col.transform != transform)
                {
                    col.GetComponent<Monster>().TakeDamage();
                }
            }
        }

        base.Die();
    }
}
