using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public static int stage;
    public static int score;
    public static float time;
    public static int itemCount;
    public static int noteCount;
    public static float noteSuccess;
    public static int monsterCount;

    public TextMeshProUGUI[] rankText;

    [Space()]
    public Text scoreText;
    public Text timeText;
    public Text itemCountText;
    public Text noteCountText;
    public Text noteSuccessText;
    public Text monsterCountText;

    [Space()]
    public GameObject rankInsertUI;
    public GameObject menuBtn;
    public TMP_InputField nameInputField;

    private void Start()
    {
        ShowRank();

        scoreText.text = score.ToString();
        timeText.text = ((int)time / 60) + ":" + ((int)time % 60);
        itemCountText.text = itemCount.ToString();
        noteCountText.text = noteCount.ToString();
        noteSuccessText.text = ((int)(noteSuccess / noteCount)).ToString();
        monsterCountText.text = monsterCount.ToString();

        rankInsertUI.SetActive(RankManager.Instance.CanInsertRank(stage, score));
        menuBtn.SetActive(!RankManager.Instance.CanInsertRank(stage, score));
    }
    
    public void ShowRank()
    {
        if (stage == 1)
        {
            for (int i=0;i<RankManager.Instance.stage1Rank.Count;i++)
            {
                rankText[i].text = $"{i+1}  /  {RankManager.Instance.stage1Rank[i].Name}  /  {RankManager.Instance.stage1Rank[i].Score}";
            }
        }
        else
        {
            for (int i = 0; i < RankManager.Instance.stage2Rank.Count; i++)
            {
                rankText[i].text = $"{i + 1}  /  {RankManager.Instance.stage2Rank[i].Name}  /  {RankManager.Instance.stage2Rank[i].Score}";
            }
        }
    }

    public void InsertRank()
    {
        RankInfo rankInfo = new RankInfo() { Name = nameInputField.text, Score = score };
        RankManager.Instance.InsertRank(stage, rankInfo);
        ShowRank();
        menuBtn.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
