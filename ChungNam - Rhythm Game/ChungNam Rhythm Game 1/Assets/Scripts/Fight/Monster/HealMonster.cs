using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMonster : Monster
{

    public override void Die()
    {
        NoteManager.Instance.TakeHeal(NoteManager.Instance.hp / 2);
        base.Die();
    }
}
