using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemie : MonoBehaviour
{
    /*
    public float speed;
    public float distance;
    public bool isRight = true;
    public Transform groundCheck;
    */

    public Animator anim;
    public SpriteRenderer sprite;

    [SerializeField] private int life = 6;
    public float moveSpeed = 3f;

    public Transform[] pointsToMove;
    public int startingPoint;

    public BoxCollider2D colliderAtk;
    public BoxCollider2D colliderCheckAtk;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        transform.position = pointsToMove[startingPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);

        if (ground.collider == false || ground.collider)
        {
            if (isRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3 (0, 180, 0);
                isRight = true;
            }
        }
        */

        if (startingPoint == 0)
        {
            sprite.flipX = true;
            colliderAtk.offset = new Vector2 (-0.33f, 0.08f);
            colliderCheckAtk.offset = new Vector2(-0.2f,0.2f);
        }
        else
        {
            sprite.flipX= false;
            colliderAtk.offset = new Vector2(0.33f, 0.08f);
            colliderCheckAtk.offset = new Vector2(0.2f, 0.2f);
        }

        if (life == 0)
        {
            EnemyDead();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[startingPoint].transform.position, moveSpeed * Time.deltaTime);

        if (EnemieMeleeCheckAttack.checkAttack == true)
        {
            StartCoroutine("Ataque");
        }
        else
        {
            anim.SetBool("Andando", true);
            anim.SetBool("Ataque", false);
        }


        if (transform.position == pointsToMove[startingPoint].transform.position)
        {
            startingPoint += 1;
        }

        if (startingPoint == pointsToMove.Length)
        {
            startingPoint = 0;
        }

        /*
        if (moveSpeed <= 0)
        {
            anim.SetBool("Andando", false);
        }
        else
        {
            anim.SetBool("Andando", true);
        }
        */
    }

    private void EnemyDead()
    {
        life = 0;
        anim.SetTrigger("Morto");
        moveSpeed = 0;
        Destroy(gameObject, 1.0f);
        Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
        Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
        Destroy(colliderAtk);
        Destroy(colliderCheckAtk);
        Destroy(this);
    }

    IEnumerator Ataque()
    {
        anim.SetBool("Ataque", false);
        anim.SetBool("Andando", false);
        moveSpeed = 0;
        yield return new WaitForSeconds(1);

        anim.SetBool("Ataque", true);
        anim.SetBool("Andando", false);
        yield return new WaitForSeconds(1);

        anim.SetBool("Ataque", false);
        anim.SetBool("Andando", true);

        moveSpeed = 2;

        EnemieMeleeCheckAttack.checkAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ataque")
        {
            life--;

            if(life < 1)
            {
                StopCoroutine("Ataque");
                EnemyDead();
            }
        }
    }
}
