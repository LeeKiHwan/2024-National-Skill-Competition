using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float hp;
    public float damage;
    public float speed;
    public int xp;
    public GameObject dieEffect;

    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        Vector3 dir = Player.Instance.transform.position - transform.position;
        transform.forward = dir.normalized;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        AttackManager.Instance.TakeXp(xp);
        GameManager.score += xp * 10;
        Destroy(Instantiate(dieEffect, transform.position + new Vector3(0, 0.5f), Quaternion.identity), 1);
        Destroy(gameObject);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AttackManager.Instance.TakeDamage(damage);
        }
    }
}
