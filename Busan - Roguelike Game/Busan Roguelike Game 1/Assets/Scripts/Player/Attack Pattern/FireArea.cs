using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    private void Awake()
    {
        transform.parent = Player.Instance.transform;
        transform.localPosition = Vector3.zero;
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        for (int i=0; i<10; i++)
        {
            Collider[] monsters = Physics.OverlapSphere(transform.position, 5);

            foreach(Collider monster in monsters)
            {
                monster.GetComponent<Monster>()?.TakeDamage(20);
            }

            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
        yield break;
    }
}
