using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float speed;

    private void Update()
    {
        if (target == null) Destroy(gameObject);
        else
        {
            transform.LookAt(target.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            other.GetComponent<Monster>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
