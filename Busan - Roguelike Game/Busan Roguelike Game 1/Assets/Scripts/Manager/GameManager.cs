using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int score;
    public int stage;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {

        }
        if (Input.GetKeyDown(KeyCode.F2))
        {

        }
        if (Input.GetKeyDown(KeyCode.F3))
        {

        }
        if (Input.GetKeyDown(KeyCode.F4))
        {

        }
        if (Input.GetKeyDown(KeyCode.F5))
        {

        }
        if (Input.GetKeyDown(KeyCode.F6))
        {

        }
    }

    public void StageClear()
    {

    }

    public IEnumerator StageClearCo()
    {
        yield break;
    }
}
