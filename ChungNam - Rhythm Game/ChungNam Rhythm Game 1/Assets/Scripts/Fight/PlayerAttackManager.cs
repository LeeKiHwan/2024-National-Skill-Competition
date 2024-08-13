using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public GameObject bullet;

    private void Start()
    {
        StartCoroutine(AttackCoroutine());
    }

    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            int attackCount = 0;
            float energyCharge = (NoteManager.Instance.groundEnergy + NoteManager.Instance.skyEnergy) / 200f;

            if (energyCharge >= 0.8f) attackCount = 8;
            else if (energyCharge >= 0.4f) attackCount = 4;
            else if (energyCharge >= 0.2f) attackCount = 2;
            else attackCount = 1;

            for (int i=0; i<attackCount; i++)
            {
                Collider[] monsters = Physics.OverlapSphere(transform.position, 50, LayerMask.GetMask("Monster"));
                monsters = monsters.ToList().OrderBy(i => Vector3.Distance(transform.position, i.transform.position)).ToArray();

                if (monsters.Length > i)
                {
                    if (monsters[i].GetComponent<Monster>().positionType == PositionType.Ground && NoteManager.Instance.groundEnergy > 0)
                    {
                        NoteManager.Instance.groundEnergy--;
                    }
                    else if (monsters[i].GetComponent<Monster>().positionType == PositionType.Sky && NoteManager.Instance.skyEnergy > 0)
                    {
                        NoteManager.Instance.skyEnergy--;
                    }
                    Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Bullet>().target = monsters[i].gameObject;
                }
            }

            yield return new WaitForSeconds(1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, 50);
    }
}
