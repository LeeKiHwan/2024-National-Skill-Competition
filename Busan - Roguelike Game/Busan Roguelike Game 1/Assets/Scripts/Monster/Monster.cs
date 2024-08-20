using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float damage;
    public float speed;
    public int score;
    public bool die;

    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        Vector3 dir = Player.Instance.transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {

    }

    public virtual void Die()
    {
        if (!die)
        {

            die = true;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
