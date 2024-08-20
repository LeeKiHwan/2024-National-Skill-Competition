using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float attackDamage;
    public float attackSpeed;

    public float maxSpeed;
    public float speed;

    public float skillCool;
    public float skillCur;

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

    public bool die;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(FireArea());
        StartCoroutine(FireBreath());
        StartCoroutine(Lightning());
        StartCoroutine(Laser());
    }

    private void Update()
    {
        skillCur -= Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        hp = Mathf.Min(hp - damage, maxHp);

        if (hp <= 0) Die();
    }

    public void TakeMp(float mp)
    {
        this.mp = Mathf.Min(this.mp + mp, maxMp);
    }

    public void TakeXp(float xp)
    {
        this.xp = Mathf.Min(this.xp + xp, maxXp);

        if (xp >= maxXp) UIManager.Instance.ShowAttackPattern();
    }

    public void IncreaseSpeed(float speed)
    {
        this.speed = Mathf.Min(this.speed + speed, maxSpeed);
    }

    public void Die()
    {
        if (!die)
        {
            die = true;
        }
    }

    public void Curse()
    {
        
    }

    public IEnumerator CurseCoroutine()
    {


        yield break;
    }

    public IEnumerator FireArea()
    {
        while (true)
        {
            if (fireAreaLevel > 0)
            {
                Instantiate(fireArea, Player.Instance.transform);
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
                Instantiate(fireBreath, Player.Instance.transform);
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
                Instantiate(lightning, Player.Instance.transform);
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
