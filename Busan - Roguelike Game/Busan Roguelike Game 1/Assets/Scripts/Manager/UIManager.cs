using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image playerHp;
    public Image playerMp;
    public Image playerXp;

    public Image[] skill;

    public TextMeshProUGUI scoreText;

    public GameObject[] attackPattern;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        playerHp.fillAmount = Mathf.Lerp(playerHp.fillAmount, AttackManager.Instance.hp / AttackManager.Instance.maxHp, Time.deltaTime * 10);
        playerMp.fillAmount = Mathf.Lerp(playerMp.fillAmount, AttackManager.Instance.mp / AttackManager.Instance.maxMp, Time.deltaTime * 10);
        playerXp.fillAmount = Mathf.Lerp(playerXp.fillAmount, AttackManager.Instance.xp / AttackManager.Instance.maxXp, Time.deltaTime * 10);

        foreach (Image skill in skill)
        {
            skill.fillAmount = AttackManager.Instance.skillCur / AttackManager.Instance.skillCool;
        }

        scoreText.text = "SCORE : " + GameManager.score + "P";
    }

    public void ShowAttackPattern()
    {
        Time.timeScale = 0;

        List<int> rands = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, attackPattern.Length);

            while (rands.Contains(rand))
            {
                rand = Random.Range(0, attackPattern.Length);
            }

            rands.Add(rand);

            attackPattern[rand].SetActive(true);
        }
    }

    public void SelectPattern(int attackPattern)
    {
        switch (attackPattern)
        {
            case 0:
                AttackManager.Instance.fireAreaLevel++;
                break;
            case 1:
                AttackManager.Instance.fireBreathLevel++;
                break;
            case 2:
                AttackManager.Instance.lightningLevel++;
                break; ;
            case 3:
                AttackManager.Instance.laserLevel++;
                break;
            case 4:
                AttackManager.Instance.AutoAttack();
                break;
        }

        for (int i=0; i<this.attackPattern.Length; i++)
        {
            this.attackPattern[i].SetActive(false);
        }

        Time.timeScale = 1;
    }
}

public enum AttackPattern
{
    FireArea,
    FireBreath,
    Lightning,
    Laser,
    AutoAttack
}
