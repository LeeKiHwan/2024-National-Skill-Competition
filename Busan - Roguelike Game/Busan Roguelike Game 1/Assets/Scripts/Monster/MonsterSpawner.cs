using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsters;
    public float spawnCool;

    public GameObject boss;
    public float bossCool;
    public bool bossSpawn;

    private void Awake()
    {
        StartCoroutine(SpawnMonster());
        //StartCoroutine(SpawnBoss());
        StartCoroutine(SpawnCool());
    }

    public IEnumerator SpawnCool()
    {
        spawnCool = 10;
        yield return new WaitForSeconds(30);
        spawnCool = 7;
        yield return new WaitForSeconds(30);
        spawnCool = 4;
        yield return new WaitForSeconds(30);
        spawnCool = 1;
    }

    public IEnumerator SpawnMonster()
    {
        while (!bossSpawn)
        {
            int rand = Random.Range(0, monsters.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

            Instantiate(monsters[rand], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnCool);
        }

        yield break;
    }

    public IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(bossCool);

        Vector3 spawnPos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        Instantiate(boss, spawnPos, Quaternion.identity);

        bossSpawn = true;

        yield break;
    }
}
