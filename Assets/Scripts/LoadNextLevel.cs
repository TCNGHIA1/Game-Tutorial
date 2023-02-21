using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public float delaySecond = 2;
    public AudioSource source;
    //when player touch the gate
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            source.Play();
            GameController.instance.always.Pause();
            SelectNextLevel();
        }
    }

    //funtion to next level
    private void SelectNextLevel()
    {
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
