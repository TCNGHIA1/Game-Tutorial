using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;
    public Text gameOverScoreText;
    public GameObject gameOverText;
    public bool isGameOver = false;
    private int score = 0;

    public AudioSource soundDeath;
    public AudioSource always;
    public AudioSource coin;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
        else if(instance ==this){
            Destroy(gameObject);
        }
    }
    public void check(bool isGameOver)
    {
        if (isGameOver == true) 
        {
            gameOverScoreText.text = "Your Score: " + this.score;
            gameOverText.SetActive(true);
            always.Stop();
            soundDeath.Play();
            this.isGameOver = true;
        }
        else
        {
            always.Play();
        }
    }
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
