using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public static int score;
    public static float time;
    public static int itemCount;
    public static int noteCount;
    public static float noteSuccess;
    public static int monsterCount;

    [Header("Text")]
    public Text scoreText;
    public Text timeText;
    public Text itemCountText;
    public Text noteCountText;
    public Text noteSuccessText;
    public Text monsterCountText;

    private void Awake()
    {
        
    }

    
}
