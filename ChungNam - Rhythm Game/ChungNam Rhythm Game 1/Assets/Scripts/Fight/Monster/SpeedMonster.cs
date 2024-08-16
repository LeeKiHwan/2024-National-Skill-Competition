using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMonster : Monster
{
    public override void Update()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 2.5f, LayerMask.GetMask("Monster"));
        foreach(Collider col in cols)
        {
            col.transform.Translate(Vector3.forward * (col.GetComponent<Monster>().speed / 2) * Time.deltaTime);
        }

        base.Update();
    }
}
