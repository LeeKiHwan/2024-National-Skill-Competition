using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public static RankManager Instance;
    public List<RankInfo> rank = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InsertRank(RankInfo rankInfo)
    {
        rank.Add(rankInfo);
        rank = rank.OrderByDescending(i => i.Score).ToList();
    }
}

public struct RankInfo
{
    public string Name;
    public int Score;
}
