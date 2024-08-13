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

    public IEnumerator EnergyDouble()
    {
        energyDouble = true;
        yield return new WaitForSeconds(4);
        energyDouble = false;

        yield break;
    }

    public IEnumerator Timer()
    {
        timer = true;
        yield return new WaitForSeconds(2);
        timer = false;

        yield break;
    }

    public IEnumerator Perfect()
    {
        perfect = true;
        yield return new WaitForSeconds(5);
        perfect = false;

        yield break;
    }
}
