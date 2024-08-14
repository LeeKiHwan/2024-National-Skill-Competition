using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHp : MonoBehaviour
{
    public Monster monster;
    public Image monsterHpImage;
    public int maxHp;

    private void Awake()
    {
        monster = GetComponentInParent<Monster>();
        maxHp = monster.hp;
    }

    private void FixedUpdate()
    {
        monsterHpImage.fillAmount = monster.hp / (float)maxHp;
    }
}
