using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartSistem : MonoBehaviour
{
    public bool isDead;

    public int vida;
    public int vidaMaxima;

    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        DeadState();
    }

    void HealthLogic() 
    {
        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }

        for (int i = 0; i < coracao.Length; i++)
        {
            if (i < vida)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vazio;
            }

            if (i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }

    void DeadState()
    {
        if (vida <= 0)
        {
            isDead = true;
            GetComponent<PlayerMoviment>().enabled = false;
            Destroy(gameObject, 1.0f);
            Menu.instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage1")
        {
            vida--;
        }
    }
}
