using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;

    //show score in left text
    private int score = 0;
    public Text scoreText;
    
    //controller when game over
    public GameObject gameOverText;
    public Text gameOverScoreText;

    //audio
    public AudioSource soundDeath;
    public AudioSource always;
    public AudioSource coin;

    //
    public bool isGameOver;
    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
        else if(instance ==this){
            Destroy(gameObject);
        }
    }
    //Check gameover
    public void check(bool GameOver)
    {
        if (GameOver) 
        {
            gameOverScoreText.text = "Your Score: " + this.score;
            gameOverText.SetActive(true);
            always.Stop();
            soundDeath.Play();
            isGameOver = true;
        }
        else
        {
            always.Play();
        }
    }

    //count score when claim coin
    public void AddScore(int score)
    {

        this.score += score;
        scoreText.text = "Score: " + this.score;

    }
    public void soundCoin(bool check)
    {
        if (check)
        {
            coin.Play();
        }
        else
        {
            coin.Stop();
        }
    }

}
