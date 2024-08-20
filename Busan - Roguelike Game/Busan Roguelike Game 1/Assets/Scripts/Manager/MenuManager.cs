using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI rankText;

    private void Start()
    {
        for (int i = 0; i < RankManager.Instance.rank.Count; i++)
        {
            rankText.text = $"{i + 1}    {RankManager.Instance.rank[i].Name}    {RankManager.Instance.rank[i].Score}P";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
