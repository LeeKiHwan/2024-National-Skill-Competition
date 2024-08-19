using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Monster
{
    public bool isStageBoss; // false면 중간 보스, true면 스테이지 보스
    public float skillCool;

    private void Start()
    {
        StartCoroutine(Skill());
    }

    public IEnumerator Skill()
    {
        while (true)
        {
            int rand = Random.Range(0, 3);

            switch (rand)
            {
                case 0:
                    StartCoroutine(UIManager.Instance.SpawnCloud());
                    break;
                case 1:
                    NoteManager.Instance.ghostSkill = true;
                    yield return new WaitForSeconds(3);
                    NoteManager.Instance.ghostSkill = false;
                    break;
                case 2:
                    StartCoroutine(UIManager.Instance.Reverse());
                    break;
            }

            yield return new WaitForSeconds(skillCool);
        }
    }

    public override void Die()
    {
        if (!isStageBoss)
        {
            MonsterSpawner.Instance.StageBossSpawn();
            MonsterSpawner.Instance.disableSpawn = false;
        }
        else
        {
            ResultManager.stage = SceneManager.GetActiveScene().name == "Stage1" ? 1 : 2;
            ResultManager.score = NoteManager.Instance.noteCount * 1500 + NoteManager.Instance.monsterCount * 1000;
            ResultManager.time = NoteManager.Instance.time;
            ResultManager.itemCount = NoteManager.Instance.itemCount;
            ResultManager.noteCount = NoteManager.Instance.noteCount;
            ResultManager.noteSuccess = NoteManager.Instance.noteSuccess;
            ResultManager.monsterCount = NoteManager.Instance.monsterCount;

            SceneManager.LoadScene("Result");
        }

        base.Die();
    }
}
