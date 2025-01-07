using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public heartSistem heart;

    private SpriteRenderer _renderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "bulletE")
        {
            heart.vida--;
        }
    }

    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _renderer.color = Color.white;
    }
}
