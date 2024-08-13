using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitMonster : Monster
{
    public GameObject childMonster;

    public override void TakeDamage()
    {
        hp--;
        StartCoroutine(Stop());

        if (hp <= 0)
        {
            for (int i=0; i<4; i++)
            {
                Instantiate(childMonster, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
