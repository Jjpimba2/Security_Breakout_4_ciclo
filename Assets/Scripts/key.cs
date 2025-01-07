using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    static private bool hasKey = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasKey = true;
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<SpriteRenderer>());
        }
    }

    static public bool GetHasKey()
    {
        return hasKey;
    }
}
