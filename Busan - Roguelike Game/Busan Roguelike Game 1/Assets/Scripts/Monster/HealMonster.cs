using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMonster : Monster
{
    public float heal;
    public float healSpeed;

    private void Awake()
    {
        StartCoroutine(Heal());
    }

    public IEnumerator Heal()
    {
        while (true)
        {
            Collider[] monsters = Physics.OverlapSphere(transform.position, 5);

            foreach(Collider monster in monsters)
            {
                if (monster.GetComponent<Monster>() != null)
                {
                    monster.GetComponent<Monster>().TakeDamage(-heal);
                }
            }

            yield return new WaitForSeconds(healSpeed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 5);
    }
}
