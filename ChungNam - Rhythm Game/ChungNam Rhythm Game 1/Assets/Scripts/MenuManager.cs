using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StageStart(int stage)
    {
        SceneManager.LoadScene("Stage" + stage);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
