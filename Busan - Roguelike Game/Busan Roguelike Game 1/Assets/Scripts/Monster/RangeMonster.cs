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
            //Collider[] player = Physics.OverlapSphere(transform.position, 10, LayerMask.GetMask("Player"));
            //if (player.Length > 0)
            //{
            //    Instantiate(bullet, transform.position + new Vector3(0, 0.5f), Quaternion.identity)
            //        .GetComponent<Bullet>().SetBullet(transform.forward, damage, speed * 5, BulletType.Monster);
            //    yield return new WaitForSeconds(attackSpeed);
            //}
            //yield return new WaitForSeconds(0.1f);

            Instantiate(bullet, transform.position + new Vector3(0, 0.5f), Quaternion.identity)
                    .GetComponent<Bullet>().SetBullet(transform.forward, damage, speed * 5, BulletType.Monster);
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
