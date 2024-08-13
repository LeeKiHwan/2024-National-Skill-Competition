using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMonster : Monster
{
    public GameObject obstacle;

    public override void TakeDamage()
    {
        hp--;
        StartCoroutine(Stop());

        if (hp <= 0)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
