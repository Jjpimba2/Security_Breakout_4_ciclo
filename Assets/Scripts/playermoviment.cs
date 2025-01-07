using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoviment : MonoBehaviour
{
    //variavel de ataque
    [SerializeField] private bool atacandoBool;

    //variaveis de andar
    public static float andar;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 6f;

    // variaveis de cameras
    [SerializeField] private Transform look;
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float cameraSpeed;
    
    //variaveis de pulo
    public bool noChao = false;
    public Transform feet;
    public float rdVerificacao;
    public LayerMask eChao;
    public float puloStrenght;

    // variavel de animação
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame without phisics
    void Update()
    {
        MovePlayer();
        
        /*
        //precaução não tirar sem rever!
        noChao = Physics2D.OverlapCircle(feet.position, rdVerificacao, eChao);

        //input do pulo do personagem
        if(Input.GetKeyDown(KeyCode.Space) && noChao == true)
            rb.velocity = Vector2.up * puloStrenght;
        */
    }

    // Update is called once per frame with phisics
    void FixedUpdate()
    {
        CameraMove();
        MovePlayerFixed();
    }

    // ações do player
    public void MovePlayerFixed()
    {
        // variaveis de
        andar = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(andar * moveSpeed, rb.velocity.y);

        //inverter a posição do personagem
        if (andar > 0)
            sprite.flipX = false;

        if (andar < 0)
            sprite.flipX = true;

        // colocar a troca de animações de andar
        if (Input.GetAxisRaw("Horizontal") != 0)
            anim.SetBool("walk", true);
        else
            anim.SetBool("walk", false);

        // colocar a troca de animações de pular
        if (feet == noChao)
            anim.SetBool("jump", false);
        else
            anim.SetBool("jump", true);

    }

    public void MovePlayer()
    {
        //reconhecer o chão
        noChao = Physics2D.OverlapCircle(feet.position, rdVerificacao, eChao);

        //input do pulo do personagem
        if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
            rb.velocity = Vector2.up * puloStrenght;

        Atacar();
    }

    void CameraMove()
    {
        cameraTarget.position = Vector3.MoveTowards(cameraTarget.position, look.position, cameraSpeed);
    }

    void FimAnimATK()
    {
        anim.SetBool("ATK", false);
        atacandoBool = false;

        moveSpeed = 6f;
    }

    // input do ataque
    private void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            atacandoBool = true;

            anim.SetBool("ATK", true);
        }

        if (atacandoBool == true && noChao == true)
        {
            moveSpeed = 0;
        }
    }
}