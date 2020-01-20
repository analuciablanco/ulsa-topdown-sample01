using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{

    Animator anim;
    SpriteRenderer spr;
    Rigidbody2D rb2d;

    // public permite que sea visible la variable en el Inspector de Unity.
    // Cabeceras serializables: una variable, aun que sea privada, es visible en el Inspector.

    [SerializeField, Range(0.1f, 20f)] float moveSpeed = 5f;

    // Se declara de esta manera preferentemente cuando no se quiere hacer visible en el Inspector.
    //float moveSpeed{get; set;}
    // Si se quiere mostrar en el Inspector, se declara de la siguiente manera:
    //public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField] Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 20f)] float rayDistance = 5f;
    [SerializeField] LayerMask groundLayer;

    [SerializeField, Range(0.1f, 20f)] float jumpForce = 7f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Método.
    void Update()
    {
        // "Axis": es para recibir valores de teclado.
        // "moveSpeed": velocidad del movimiento (modificable en el Inspector).
        transform.Translate(Axis * moveSpeed * Time.deltaTime);
        spr.flipX = Flip;
    }

    void FixedUpdate()
    {
        if(Grounding)
        {
            if(JumpButton)
            {
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("jump");
            }   
        }
    }

    void LateUpdate()
    {
        anim.SetFloat("moveX", Mathf.Abs(Axis.x));
        anim.SetBool("landing", Grounding);
    }

    // Funcion: método con return.
    Vector2 Axis 
    {
        // get: devuelve
        // =>: indica lo que va a encapsular
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    // Hace lo mismo que el anterior, tambien es una función.
    /* Vector2 Axis2()
    {
        return new Vector2();
    } */

    // Se declara así para que se muestre en el Inspector.
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    bool Flip
    {
        get => Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
    }

    bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    bool JumpButton
    {
        get => Input.GetButtonDown("Jump");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
