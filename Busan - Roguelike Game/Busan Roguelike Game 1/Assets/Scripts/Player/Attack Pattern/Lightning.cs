using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject lightningEffect;

    private void Awake()
    {
        for (int i=0; i<AttackManager.Instance.lightningLevel * 2; i++)
        {
            float x = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);
            Vector3 spawnPos = transform.position + new Vector3(x, 0, z);

            Destroy(Instantiate(lightningEffect, spawnPos, Quaternion.identity), 2);
            Collider[] monsters = Physics.OverlapSphere(spawnPos, 2);
            foreach(Collider monster in monsters)
            {
                monster.GetComponent<Monster>()?.TakeDamage(100);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
