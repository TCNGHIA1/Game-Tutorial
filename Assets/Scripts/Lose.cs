using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public float loseHeight  = -65f;
    void Update()
    {
        if (gameObject.transform.position.y < loseHeight)
        {
            gameObject.SetActive(false);
            GameController.instance.check(true);
            Time.timeScale= 0;
        }
    }
}
