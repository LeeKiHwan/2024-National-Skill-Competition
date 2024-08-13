using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMonster : Monster
{
    public override void TakeDamage()
    {
        hp--;
        StartCoroutine(Stop());

        if (hp <= 0)
        {
            NoteManager.Instance.TakeHeal(NoteManager.Instance.hp / 2);
            Destroy(gameObject);
        }
    }
}
