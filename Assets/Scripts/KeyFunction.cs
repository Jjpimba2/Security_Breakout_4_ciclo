using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    public GameObject endGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (key.GetHasKey() == true && collision.gameObject.tag == "porta")
        {
            endGame.SetActive(true);
            GetComponent<PlayerMoviment>().enabled = false;
        }
    }
}
