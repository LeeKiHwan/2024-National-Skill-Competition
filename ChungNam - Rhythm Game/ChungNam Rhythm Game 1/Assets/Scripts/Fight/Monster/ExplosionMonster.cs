using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMonster : Monster
{
    public override void TakeDamage()
    {
        hp--;
        StartCoroutine(Stop());

        if (hp <= 0)
        {
            // ����Ʈ �߰� �ʿ�

            Collider[] cols = Physics.OverlapSphere(transform.position, 1.5f);

            foreach (Collider col in cols)
            {
                if (col.GetComponent<Monster>() != null)
                {
                    col.GetComponent<Monster>().TakeDamage();
                }
            }

            Destroy(gameObject);
        }
    }
}
