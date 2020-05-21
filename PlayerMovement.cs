using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //variáveis essenciais para as animações e físicas
    private Rigidbody2D rb2d;
    private Animator anim;

    //variáveis que podem ser editadas no Unity
    public float speed = 7.0f;
    public float x_mov; //-1 OU 1 OU 0

    private void Start()
    {
        //definir os gameObjects do jogador
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //trata do entrada das físicas
    private void Update()
    {
        //verificar se o jogador tem entrada de movimento
        x_mov = Input.GetAxisRaw("Horizontal");
    }

    //trata
    private void FixedUpdate()
    {
        //mover o jogador à esquerda e à direita
        rb2d.velocity = new Vector2(x_mov * speed, rb2d.velocity.y);
    }
}
