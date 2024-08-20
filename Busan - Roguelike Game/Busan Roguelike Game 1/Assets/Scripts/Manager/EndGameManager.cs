using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI scoreText;

    public GameObject menuBtn;
    public GameObject insertRankUI;
    public TMP_InputField nameIF;

    private void Awake()
    {
        Cursor.visible = true;

        scoreText.text = "SCORE : " + GameManager.score + "P";

        if (RankManager.Instance.rank.Count < 5 || RankManager.Instance.rank[4].Score < GameManager.score)
        {
            insertRankUI.SetActive(true);
            menuBtn.SetActive(false);
        }
    }

    public void ShowRank()
    {
        for (int i=0; i<RankManager.Instance.rank.Count; i++)
        {
            rankText.text = $"{i + 1}    {RankManager.Instance.rank[i].Name}    {RankManager.Instance.rank[i].Score}P";
        }
    }

    public void InsertRank()
    {
        RankInfo rankInfo = new RankInfo() { Name = nameIF.text, Score = GameManager.score };
        RankManager.Instance.InsertRank(rankInfo);
        ShowRank();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
