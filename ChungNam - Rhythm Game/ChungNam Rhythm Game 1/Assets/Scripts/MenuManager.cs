using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI[] stage1RankText;
    public TextMeshProUGUI[] stage2RankText;

    public KeyCode GroundLeft;
    public KeyCode GroundLeftCenter;
    public KeyCode GroundRightCenter;
    public KeyCode GroundRight;

    private void Start()
    {
        ShowRank();

        GroundLeft = KeyCode.A;
        GroundLeftCenter = KeyCode.S;
        GroundRightCenter = KeyCode.D;
        GroundRight = KeyCode.F;
    }

    private void Update()
    {
        foreach(KeyCode inputKey in Enum.GetValues(typeof(KeyCode)))
        {
            if (inputKey.ToString().Length == 1 && inputKey.ToString()[0] >= 65 && inputKey.ToString()[0] <= 90 && Input.GetKeyDown(inputKey))
            {
                if (inputKey != GroundLeft && inputKey != GroundLeftCenter && inputKey != GroundRightCenter && inputKey != GroundRight)
                {
                    Debug.Log(inputKey);
                }
            }
        }
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

    public void Quit()
    {
        Application.Quit();
    }
}
