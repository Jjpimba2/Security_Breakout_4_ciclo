using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKplayer : MonoBehaviour
{
    // script para reconhecer o ataque do personagem
    public BoxCollider2D colliderAtkPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        colliderAtkPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //inversão do colisor conforme posição do personagem
        if (PlayerMoviment.andar < 0)
        {
            colliderAtkPlayer.offset = new Vector2 (-0.6f, 0);
        } else if(PlayerMoviment.andar > 0)
        {
            colliderAtkPlayer.offset = new Vector2(0.6f, 0);
        }
    }
}
