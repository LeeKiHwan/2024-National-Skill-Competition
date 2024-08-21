using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        transform.position = Player.Instance.transform.position;
        transform.forward = Player.Instance.transform.forward;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<Monster>().TakeDamage(Time.deltaTime * 20);
        }
    }
}
