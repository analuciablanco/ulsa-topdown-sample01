using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{

    // public permite que sea visible la variable en el Inspector de Unity.
    // Cabeceras serializables: una variable, aun que sea privada, es visible en el Inspector.

    [SerializeField] float moveSpeed = 5f;

    // Se declara de esta manera preferentemente cuando no se quiere hacer visible en el Inspector.
    //float moveSpeed{get; set;}
    // Si se quiere mostrar en el Inspector, se declara de la siguiente manera:
    //public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    // Método.
    void Update()
    {
        // "Axis": es para recibir valores de teclado.
        // "moveSpeed": velocidad del movimiento (modificable en el Inspector).
        transform.Translate(Axis * moveSpeed * Time.deltaTime);
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
}
