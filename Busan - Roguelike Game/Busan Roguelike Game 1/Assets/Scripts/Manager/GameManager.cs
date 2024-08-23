using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int score;
    public int stage;

    public bool monsterCheatOn;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {

        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            AttackManager.Instance.TakeXp(AttackManager.Instance.maxXp);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            AttackManager.Instance.isInvc = !AttackManager.Instance.isInvc;
            AttackManager.Instance.invcEffect.SetActive(AttackManager.Instance.isInvc);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            AttackManager.Instance.TakeDamage(-AttackManager.Instance.maxHp);
            AttackManager.Instance.mp = AttackManager.Instance.maxMp;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            monsterCheatOn = !monsterCheatOn;

            UIManager.Instance.monsterCheatUI.SetActive(monsterCheatOn);
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            Monster[] monsters = FindObjectsOfType<Monster>();
            foreach(Monster monster in monsters)
            {
                monster.TakeDamage(1000000);
            }
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }

        if (monsterCheatOn)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                GameObject m = FindObjectOfType<MonsterSpawner>().monsters[0];
                Instantiate(m, Vector3.zero, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                GameObject m = FindObjectOfType<MonsterSpawner>().monsters[1];
                Instantiate(m, Vector3.zero, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                GameObject m = FindObjectOfType<MonsterSpawner>().monsters[2];
                Instantiate(m, Vector3.zero, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                GameObject m = FindObjectOfType<MonsterSpawner>().monsters[3];
                Instantiate(m, Vector3.zero, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject m = FindObjectOfType<MonsterSpawner>().monsters[4];
                Instantiate(m, Vector3.zero, Quaternion.identity);
            }
        }
    }

    public void StageClear()
    {

    }

    public IEnumerator StageClearCo()
    {
        yield break;
    }
}
