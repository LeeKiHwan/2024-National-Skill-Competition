using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 pos;

    private void Awake()
    {
        float x = Random.Range(-0.5f, 0.5f);
        float y = Random.Range(1.25f, 1.75f);
        float z = Random.Range(-0.5f, 0.5f);
        pos = new Vector3(x, y, z);

        StartCoroutine(Attack());
    }

    private void Update()
    {
        transform.position = Player.Instance.transform.position + pos;
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            Collider[] monsters = Physics.OverlapSphere(Player.Instance.transform.position, 25);

            foreach (Collider monster in monsters)
            {
                if (monster.GetComponent<Monster>() != null)
                {
                    Vector3 fwd = monster.transform.position - transform.position;

                    Instantiate(bullet, transform.position, Quaternion.identity).
                        GetComponent<Bullet>().SetBullet(fwd.normalized, 10, 10, BulletType.Player);

                    yield return new WaitForSeconds(2);

                    break;
                }
            }

            yield return null;
        }
    }
}
