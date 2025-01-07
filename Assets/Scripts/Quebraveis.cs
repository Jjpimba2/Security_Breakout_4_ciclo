using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quebraveis : MonoBehaviour
{
    [SerializeField] private int vidaQuebraveis = 3;

    public SpriteRenderer quebravel;
    public Sprite[] quebravelImagem = new Sprite[3];

    // Start is called before the first frame update
    void Start()
    {
        quebravel = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (vidaQuebraveis)
        {
            case 3:
                quebravel.sprite = quebravelImagem[2];
                break;
            case 2:
                quebravel.sprite = quebravelImagem[1];
                break;
            case 1:
                quebravel.sprite = quebravelImagem[0];
                break;
            case 0:
                GetComponent<Animator>().enabled = true;
                Destroy(GetComponent<Animator>(), 1);

                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<Quebraveis>());
                Destroy(GetComponent<SpriteRenderer>(),5);
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ataque")
        {
            vidaQuebraveis--;
        }
    }
}
