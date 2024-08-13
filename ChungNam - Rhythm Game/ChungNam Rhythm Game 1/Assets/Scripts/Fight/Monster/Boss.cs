using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    public bool isStageBoss; // false�� �߰� ����, true�� �������� ����
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
}
