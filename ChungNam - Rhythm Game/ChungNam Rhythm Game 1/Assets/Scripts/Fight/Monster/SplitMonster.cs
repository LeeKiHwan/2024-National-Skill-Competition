using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitMonster : Monster
{
    public GameObject childMonster;

    public override void Die()
    {
        Instantiate(childMonster, transform.position + new Vector3(1.5f, 1.5f), Quaternion.identity);
        Instantiate(childMonster, transform.position + new Vector3(-1.5f, 1.5f), Quaternion.identity);
        Instantiate(childMonster, transform.position + new Vector3(1.5f, -1.5f), Quaternion.identity);
        Instantiate(childMonster, transform.position + new Vector3(-1.5f, -1.5f), Quaternion.identity);

        base.Die();
    }
}
