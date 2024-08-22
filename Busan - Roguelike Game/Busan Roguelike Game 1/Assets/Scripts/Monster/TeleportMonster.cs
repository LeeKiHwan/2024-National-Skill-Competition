using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMonster : Monster
{
    public GameObject teleportEffect;
    public float teleportCool;

    private void Awake()
    {
        StartCoroutine(Teleport());
    }

    public IEnumerator Teleport()
    {
        while (true)
        {
            Collider[] player = Physics.OverlapSphere(transform.position, 10);

            foreach(Collider collider in player)
            {
                if (collider != null && collider.CompareTag("Player"))
                {
                    transform.position = collider.transform.position + (-collider.transform.forward * 2);
                    Destroy(Instantiate(teleportEffect, transform.position, Quaternion.identity), 3);

                    yield return new WaitForSeconds(teleportCool);
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
