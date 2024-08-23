using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackManager : MonoBehaviour
{
    public static AttackManager Instance;

    [Space()]
    public float maxHp;
    public float hp;

    public float maxMp;
    public float mp;

    public float maxXp;
    public float xp;

    [Space()]
    public GameObject attackBullet;
    public float attackDamage;
    public float attackSpeed;

    public float maxSpeed;
    public float speed;

    public float skillCool;
    public float skillCur;

    public GameObject invcEffect;
    public bool isInvc;
    public bool isCurse;

    [Space()]
    public GameObject teleportEffect;

    [Space()]
    public int fireAreaLevel;
    public GameObject fireArea;

    public int fireBreathLevel;
    public GameObject fireBreath;

    public int lightningLevel;
    public GameObject lightning;

    public int laserLevel;
    public GameObject laser;

    public GameObject autoAttack;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance.hp = maxHp;
            Instance.maxMp = maxMp;

            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(Attack());
        StartCoroutine(FireArea());
        StartCoroutine(FireBreath());
        StartCoroutine(Lightning());
        StartCoroutine(Laser());
        StartCoroutine(GetMp());
    }

    private void Update()
    {
        UseSkill();
    }

    public void TakeDamage(float damage)
    {
        if (isInvc) return;

        hp = Mathf.Min(hp - damage, maxHp);

        if (hp <= 0) Die();
    }

    public IEnumerator GetMp()
    {
        while (true)
        {
            mp = Mathf.Min(mp + Time.deltaTime, maxMp);
            yield return null;
        }
    }

    public void TakeXp(float xp)
    {
        this.xp = Mathf.Min(this.xp + xp, maxXp);

        if (this.xp >= maxXp)
        {
            maxXp *= 1.15f;
            this.xp = 0;
            UIManager.Instance.ShowAttackPattern();
        }
    }

    public void IncreaseSpeed(float speed)
    {
        this.speed = Mathf.Min(this.speed + speed, maxSpeed);
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UseSkill()
    {
        skillCur -= Time.deltaTime;

        if (isCurse) return;

        if (Input.GetKeyDown(KeyCode.Alpha1) && skillCur <= 0 && mp >= 30)
        {
            for (int i=0; i < 10; i++)
            {
                Vector3 fwd = Player.Instance.transform.forward + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));

                Instantiate(attackBullet, Player.Instance.transform.position + new Vector3(0, 0.5f), Quaternion.identity).
                        GetComponent<Bullet>().SetBullet(fwd, attackDamage, 25, BulletType.Player);
            }

            mp -= 30;
            skillCur = skillCool;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && skillCur <= 0 && mp >= 20)
        {
            Player.Instance.transform.Translate(Vector3.forward * 5);
            Destroy(Instantiate(teleportEffect, Player.Instance.transform.position, Quaternion.identity), 3);

            mp -= 20;
            skillCur = skillCool;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && skillCur <= 0 && mp >= 20)
        {
            StartCoroutine(AttackSpeedUp());
            mp -= 20;
            skillCur = skillCool;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && skillCur <= 0 && mp >= 30)
        {
            TakeDamage(-10);
            mp -= 30;
            skillCur = skillCool;
        }
    }

    public IEnumerator AttackSpeedUp()
    {
        attackSpeed += 5;
        yield return new WaitForSeconds(3);
        attackSpeed -= 5;

        yield break;
    }

    public void Curse()
    {
        StartCoroutine(CurseCoroutine());
    }

    public IEnumerator CurseCoroutine()
    {
        isCurse = true;
        yield return new WaitForSeconds(2);
        isCurse = false;

        yield break;
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            Instantiate(attackBullet, Player.Instance.transform.position + new Vector3(0, 0.5f), Quaternion.identity).
                    GetComponent<Bullet>().SetBullet(Player.Instance.transform.forward, attackDamage, 25, BulletType.Player);

            yield return new WaitForSeconds(1 / attackSpeed);
        }
    }

    public IEnumerator FireArea()
    {
        while (true)
        {
            if (fireAreaLevel > 0)
            {
                Instantiate(fireArea, Player.Instance.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(10 / fireAreaLevel);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator FireBreath()
    {
        while (true)
        {
            if (fireBreathLevel > 0)
            {
                Instantiate(fireBreath, Player.Instance.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(10 / fireBreathLevel);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator Lightning()
    {
        while (true)
        {
            if (lightningLevel > 0)
            {
                Instantiate(lightning, Player.Instance.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(10 / lightningLevel);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator Laser()
    {
        while (true)
        {
            if (laserLevel > 0)
            {
                Instantiate(laser, Player.Instance.transform);
                yield return new WaitForSeconds(10 /  laserLevel);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void AutoAttack()
    {
        Instantiate(autoAttack, Player.Instance.transform);
    }
}
