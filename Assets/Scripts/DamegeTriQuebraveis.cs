using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeTriQuebraveis : MonoBehaviour
{
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Quebravel")
        {
            vidaCaixa.vidaQuebraveis--;
        }
    }
    */

    /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ataque")
        {
            Quebraveis.vidaQuebraveis--;

            if (Quebraveis.vidaQuebraveis < 1)
            {
                Destroy(this);
                Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
            }
        }
    }
    */
}
