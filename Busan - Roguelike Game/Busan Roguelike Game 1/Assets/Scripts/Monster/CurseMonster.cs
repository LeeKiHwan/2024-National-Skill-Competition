using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseMonster : Monster
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player")) AttackManager.Instance.Curse();
    }
}
