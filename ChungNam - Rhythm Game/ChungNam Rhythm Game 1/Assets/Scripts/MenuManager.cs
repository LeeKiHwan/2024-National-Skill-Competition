using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI[] stage1RankText;
    public TextMeshProUGUI[] stage2RankText;

    private void Start()
    {
        ShowRank();
    }

    public void StageStart(int stage)
    {
        SceneManager.LoadScene("Stage" + stage);
    }

    public void ShowRank()
    {
        for (int i=0; i<RankManager.Instance.stage1Rank.Count; i++)
        {
            stage1RankText[i].text = $"{i + 1}  /  {RankManager.Instance.stage1Rank[i].Name}  /  {RankManager.Instance.stage1Rank[i].Score}";
        }
        for (int i = 0; i < RankManager.Instance.stage2Rank.Count; i++)
        {
            stage2RankText[i].text = $"{i + 1}  /  {RankManager.Instance.stage2Rank[i].Name}   /   {RankManager.Instance.stage2Rank[i].Score}";
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
