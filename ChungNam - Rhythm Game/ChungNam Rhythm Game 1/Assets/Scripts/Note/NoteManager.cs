using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [Header("ground key")]
    public KeyCode leftGround;
    public KeyCode leftCenterGround;
    public KeyCode rightCenterGround;
    public KeyCode rightGround;

    [Header("sky key")]
    public KeyCode leftSky;
    public KeyCode leftCenterSky;
    public KeyCode rightCenterSky;
    public KeyCode rightSky;

    [Header("info")]
    public int hp;
    public int combo;
    public int groundEnergy;
    public int skyEnergy;
    public bool isDie;

    [Header("Result")]
    public int score;
    public float time;
    public int itemCount;
    public int noteCount;
    public float noteSuccess;
    public int monsterCount;

    [Header("item info")]
    public bool energyDouble;
    public int missDefense;
    public bool timer;
    public bool perfect;

    [Header("boss skill")]
    public bool ghostSkill;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void AddGroundEnergy(int energy)
    {
        if (energyDouble) energy *= 2;

        if (groundEnergy + energy < 100) groundEnergy += energy;
        else groundEnergy = 100;
    }

    public void AddSkyEnergy(int energy)
    {
        if (energyDouble) energy *= 2;

        if (skyEnergy + energy < 100) skyEnergy += energy;
        else skyEnergy = 100;
    }

    public void TakeHeal(int heal)
    {
        if (hp + heal < 100) hp += heal;
        else hp = 100;
    }

    public void TakeDamage(int damage)
    {
        if (hp - damage > 0) hp -= damage;
        else
        {
            hp = 0;
            Die();
        }
    }

    public void Die()
    {
        if (!isDie)
        {
            isDie = true;
        }
    }

    public void GetItem(int index)
    {
        switch (index)
        {
            case 0:
                StartCoroutine(EnergyDoubleCo());
                break;
            case 1:
                StartCoroutine(TimerCo());
                break;
            case 2:
                StartCoroutine(PerfectCo());
                break;
        }
    }

    public IEnumerator EnergyDoubleCo()
    {
        energyDouble = true;
        yield return new WaitForSeconds(4);
        energyDouble = false;

        yield break;
    }

    public IEnumerator TimerCo()
    {
        timer = true;
        yield return new WaitForSeconds(2);
        timer = false;

        yield break;
    }

    public IEnumerator PerfectCo()
    {
        perfect = true;
        yield return new WaitForSeconds(5);
        perfect = false;

        yield break;
    }
}
