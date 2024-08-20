using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMonster : Monster
{
    public GameObject bullet;
    public float attackSpeed;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            Collider[] player = Physics.OverlapSphere(transform.position, 5, LayerMask.GetMask("Player"));
            if (player.Length > 0)
            {
                GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
                b.transform.forward = transform.forward;
                b.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.VelocityChange);

                yield return new WaitForSeconds(attackSpeed);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
