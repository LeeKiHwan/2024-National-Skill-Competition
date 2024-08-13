using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    public KeyCode leftGround;
    public KeyCode leftCenterGround;
    public KeyCode rightCenterGround;
    public KeyCode rightGround;

    public KeyCode leftSky;
    public KeyCode leftCenterSky;
    public KeyCode rightCenterSky;
    public KeyCode rightSky;

    public int combo;

    public int hp;
    public int groundEnergy;
    public int skyEnergy;

    public int missDefense;

    public bool isDie;

    private void Awake()
    {
        Instance = this;
    }

    public void AddGroundEnergy(int energy)
    {
        if (groundEnergy + energy < 100) groundEnergy += energy;
        else groundEnergy = 100;
    }

    public void AddSkyEnergy(int energy)
    {
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
}
