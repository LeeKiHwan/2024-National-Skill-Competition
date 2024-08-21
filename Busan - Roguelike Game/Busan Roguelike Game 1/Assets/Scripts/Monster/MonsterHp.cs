using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHp : MonoBehaviour
{
    public float maxHp;
    public Monster monster;
    public Image monsterHp;

    private void Awake()
    {
        monster = GetComponentInParent<Monster>();
        maxHp = monster.hp;
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);

        monsterHp.fillAmount = Mathf.Lerp(monsterHp.fillAmount, monster.hp / maxHp, Time.deltaTime * 5);
    }
}
