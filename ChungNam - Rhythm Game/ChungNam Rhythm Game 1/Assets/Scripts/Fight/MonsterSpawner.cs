using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsters;
    public Transform[] spawnPos;

    public IEnumerator MonsterSpawn()
    {
        while (true)
        {
            List<int> index = new List<int>();

            for (int i=0; i<4; i++)
            {
                int randSpawn = Random.Range(0, 4);
                int randMonster = Random.Range(0, monsters.Length);

                while (!index.Contains(randSpawn))
                {
                    randSpawn = Random.Range(0, 4);
                }

                Instantiate(monsters[randMonster], spawnPos[randSpawn].position, Quaternion.identity);

                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(5);
        }
    }
}
