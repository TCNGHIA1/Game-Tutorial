using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadCurrentScene : MonoBehaviour
{
    public void ReloadScene()
    {
        if(GameController.instance.isGameOver)
        {
            GameController.instance.isGameOver= false;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
