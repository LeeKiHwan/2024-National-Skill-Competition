using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner Instance;

    public GameObject[] monsters;
    public Transform[] spawnPos;
    public GameObject middleBoss;
    public GameObject stageBoss;
    public bool disableSpawn;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(MonsterSpawn());
        StartCoroutine(MiddleBossSpawn());
    }

    public IEnumerator MonsterSpawn()
    {
        while (true)
        {
            if (!disableSpawn)
            {
                List<int> index = new List<int>();

                for (int i = 0; i < 4; i++)
                {
                    int randSpawn = Random.Range(0, 4);
                    int randMonster = Random.Range(0, monsters.Length);

                    while (index.Contains(randSpawn))
                    {
                        randSpawn = Random.Range(0, 4);
                    }
                    index.Add(randSpawn);

                    if (monsters[randMonster].GetComponent<Monster>().positionType == PositionType.Ground)
                    {
                        Instantiate(monsters[randMonster], spawnPos[randSpawn].position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(monsters[randMonster], spawnPos[randSpawn].position + new Vector3(0, 10, 0), Quaternion.identity);
                    }
                    UIManager.Instance.AddSpawnText(randSpawn + 1);

                    yield return new WaitForSeconds(3);
                }
            }

            yield return new WaitForSeconds(6);
        }
    }

    public IEnumerator MiddleBossSpawn()
    {
        yield return new WaitForSeconds(20);
        StartCoroutine(UIManager.Instance.BossSpawnText("중간 보스", 10));
        yield return new WaitForSeconds(10);

        Instantiate(middleBoss, transform.position, Quaternion.identity);
        disableSpawn = true;

        yield break;
    }

    public void StageBossSpawn()
    {
        StartCoroutine(StageBossSpawnCoroutine());
    }

    public IEnumerator StageBossSpawnCoroutine()
    {
        yield return new WaitForSeconds(20);
        StartCoroutine(UIManager.Instance.BossSpawnText("스테이지 보스", 20));
        yield return new WaitForSeconds(20);

        Instantiate(stageBoss, transform.position, Quaternion.identity);
        disableSpawn = true;

        yield break;
    }
}
