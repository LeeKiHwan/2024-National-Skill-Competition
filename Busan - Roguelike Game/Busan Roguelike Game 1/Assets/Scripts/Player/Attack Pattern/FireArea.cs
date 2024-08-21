using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Attack());
    }

    private void Update()
    {
        transform.position = Player.Instance.transform.position;
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.1f);

        Collider[] monsters = Physics.OverlapSphere(transform.position, 6);

        foreach (Collider monster in monsters)
        {
            monster.GetComponent<Monster>()?.TakeDamage(30);
        }

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
        yield break;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 6);
    }
}
