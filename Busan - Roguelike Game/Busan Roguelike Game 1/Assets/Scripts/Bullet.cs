using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public BulletType bulletType;

    public void SetBullet(Vector3 foward, float damage, float speed, BulletType bulletType)
    {
        transform.forward = foward;
        this.speed = speed;
        this.damage = damage;
        this.bulletType = bulletType;

        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.VelocityChange);

        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster") && bulletType == BulletType.Player)
        {
            other.GetComponent<Monster>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && bulletType == BulletType.Monster)
        {
            AttackManager.Instance.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

public enum BulletType
{
    Player,
    Monster
}
