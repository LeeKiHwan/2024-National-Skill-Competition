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
        playerHp.fillAmount = Mathf.Lerp(playerHp.fillAmount, AttackManager.Instance.hp / AttackManager.Instance.maxHp, Time.deltaTime);
        playerMp.fillAmount = Mathf.Lerp(playerMp.fillAmount, AttackManager.Instance.mp / AttackManager.Instance.maxMp, Time.deltaTime);
        playerXp.fillAmount = Mathf.Lerp(playerXp.fillAmount, AttackManager.Instance.xp / AttackManager.Instance.maxXp, Time.deltaTime);

        foreach(Image skill in skill)
        {
            skill.fillAmount = AttackManager.Instance.skillCur / AttackManager.Instance.skillCool;
        }

        scoreText.text = "SCORE : " + GameManager.score + "P";
    }

    public void ShowAttackPattern()
    {
        Time.timeScale = 0;

        List<int> rands = new List<int>();

        for (int i=0; i<3; i++)
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

    public void SelectPattern()
    {

    }
}
