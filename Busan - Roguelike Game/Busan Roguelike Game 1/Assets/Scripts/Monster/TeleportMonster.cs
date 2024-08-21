using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMonster : Monster
{
    public float teleportCool;

    private void Awake()
    {
        StartCoroutine(Teleport());
    }

    public IEnumerator Teleport()
    {
        while (true)
        {
            Collider[] player = Physics.OverlapSphere(transform.position, 5, LayerMask.GetMask("Player"));

            if (player.Length > 0)
            {
                transform.position = player[0].transform.position + -player[0].transform.forward;

                yield return new WaitForSeconds(teleportCool);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
