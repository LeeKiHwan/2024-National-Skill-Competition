using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankManager : MonoBehaviour
{
    public static RankManager Instance;

    public List<RankInfo> stage1Rank = new();
    public List<RankInfo> stage2Rank = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            for (int i = 0; i < 10; i++)
            {
                if (PlayerPrefs.HasKey("Stage1Name" + i))
                {
                    stage1Rank[i] = new RankInfo() { Name = PlayerPrefs.GetString("Stage1Name" + i), Score = PlayerPrefs.GetInt("Stage1Score" + i) };
                }
                if (PlayerPrefs.HasKey("Stage2Name" + i))
                {
                    stage2Rank[i] = new RankInfo() { Name = PlayerPrefs.GetString("Stage2Name" + i), Score = PlayerPrefs.GetInt("Stage2Score" + i) };
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InsertRank(int stage, RankInfo rankInfo)
    {
        if (stage == 1)
        {
            stage1Rank.Add(new RankInfo() { Name = rankInfo.Name, Score = rankInfo.Score });
            stage1Rank = stage1Rank.OrderByDescending(i => i.Score).ToList();
        }
        else
        {
            stage2Rank.Add(new RankInfo() { Name = rankInfo.Name, Score = rankInfo.Score });
            stage2Rank = stage2Rank.OrderByDescending(i => i.Score).ToList();
        }

        for (int i = 0; i < Mathf.Min(stage1Rank.Count, 10); i++)
        {
            PlayerPrefs.SetString("Stage1Name" + i, stage1Rank[i].Name);
            PlayerPrefs.SetInt("Stage1Score" + i, stage1Rank[i].Score);
        }
        for (int i = 0; i < Mathf.Min(stage2Rank.Count, 10); i++)
        {
            PlayerPrefs.SetString("Stage2Name" + i, stage2Rank[i].Name);
            PlayerPrefs.SetInt("Stage2Score" + i, stage2Rank[i].Score);
        }

        PlayerPrefs.Save();
    }

    public bool CanInsertRank(int stage, int score)
    {
        if (stage == 1)
        {
            if ((stage1Rank.Count >= 10 && stage1Rank[10].Score < score) || stage1Rank.Count < 10) return true;
        }
        else
        {
            if ((stage2Rank.Count >= 10 && stage2Rank[10].Score < score) || stage2Rank.Count < 10) return true;
        }
        return false;
    }
}

[System.Serializable]
public struct RankInfo
{
    public string Name;
    public int Score; 
}
