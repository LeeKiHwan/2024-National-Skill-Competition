using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMonster : Monster
{
    public GameObject obstacle;

    public override void Die()
    {
        Destroy(Instantiate(obstacle, transform.position, Quaternion.identity), 10);

        base.Die();
    }
}
