using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.soundCoin(true);
            GameController.instance.AddScore(coinValue);
            Destroy(gameObject);
        }
        else
        {
            GameController.instance.soundCoin(false);
        }

    }
}
