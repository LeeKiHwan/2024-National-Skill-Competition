using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Collider[] monsters = Physics.OverlapSphere(Player.Instance.transform.position, 25).
                ToList().OrderBy(i => Vector3.Distance(transform.position, i.transform.position)).ToArray();

            foreach (Collider monster in monsters)
            {
                if (monster.GetComponent<Monster>() != null)
                {
                    Vector3 fwd = monster.transform.position - transform.position;

                    Instantiate(bullet, transform.position, Quaternion.identity).
                        GetComponent<Bullet>().SetBullet(fwd.normalized, 30, 20, BulletType.Player);

                    yield return new WaitForSeconds(1.5f);

                    break;
                }
            }

            yield return null;
        }
    }
}
