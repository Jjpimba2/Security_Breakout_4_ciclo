using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    static public Menu instance;
    public GameObject endGame;
    public GameObject gameOver;


    void Awake()
    {
        instance = this;
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void FimDeJogo()
    {
        endGame.SetActive(true);
    }
}
