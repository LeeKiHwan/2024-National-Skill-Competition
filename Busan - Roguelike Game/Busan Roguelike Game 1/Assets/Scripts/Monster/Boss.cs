using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Monster
{
    public GameObject groundAttack;
    public GameObject dashIndct;
    public GameObject dashEffect;
    public Animator anim;
    public float attackCool;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        while (hp > 0)
        {
            if (GameManager.Instance.stage == 0)
            {
                int rand = Random.Range(0, 2);

                if (rand == 0)
                {
                    anim.SetTrigger("GroundAttack");

                    Vector3 pos = transform.position;
                    Vector3 fwd = transform.forward;

                    for (int i=1; i<5; i++)
                    {
                        GameObject g = Instantiate(groundAttack, pos, Quaternion.identity);
                        g.transform.forward = fwd;
                        g.transform.Translate(Vector3.forward * i * 3);

                        Destroy(g, 1);

                        yield return new WaitForSeconds(0.5f);
                    }
                }
                else
                {
                    dashIndct.SetActive(true);
                    yield return new WaitForSeconds(0.5f);

                    dashIndct.SetActive(false);
                    dashEffect.SetActive(true);

                    Rigidbody rb = GetComponent<Rigidbody>();

                    rb.AddForce(transform.forward * 10, ForceMode.VelocityChange);
                    yield return new WaitForSeconds(0.5f);
                    rb.velocity = Vector3.zero;

                    dashEffect.SetActive(false);
                }
            }


            yield return new WaitForSeconds(attackCool);
        }

        yield break;
    }

    public override void Die()
    {
        SceneManager.LoadScene("Rank");

        Destroy(gameObject);
    }
}
