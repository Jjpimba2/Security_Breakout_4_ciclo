using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerTeleport : MonoBehaviour
{

    private GameObject currentTeleport;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentTeleport != null)
            {
                transform.position = currentTeleport.GetComponent<TelePort>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TP"))
        {
            currentTeleport = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TP"))
        {
            if(collision.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


}
