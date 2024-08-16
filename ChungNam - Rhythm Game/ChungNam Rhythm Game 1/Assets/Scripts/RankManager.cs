using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public static List<RankInfo> stage1Rank = new List<RankInfo>();
    public static List<RankInfo> stage2Rank = new List<RankInfo>();
    public TextMeshProUGUI[] stage1RankText;
    public TextMeshProUGUI[] stage2RankText;

    private void Awake()
    {
        for (int i = 0; i<stage1Rank.Count;  i++)
        {
            stage1RankText[i].text = $"{i + 1}  /  {stage1Rank[i].Name}  /  {stage1Rank[i].Score}";
        }
    }
}

public struct RankInfo
{
    public string Name;
    public int Score; 
}
