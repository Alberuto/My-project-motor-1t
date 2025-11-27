using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour{

    [Header("Ajustes de movimiento")]
    [SerializeField] private int velocidad;

    [Header("Tiempo de vida")]
    [SerializeField] private int tiempoVida;

    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoDisparo;
    [SerializeField] private AudioSource sonidoExplosion;

    [Header("Efectos")]
    [SerializeField] private GameObject efectoImpacto;

    private Rigidbody2D rb;

    List<string> colorTags = new List<string> { "Rojo", "Azul", "Rosa", "Verde", "Negro" };

    void Start(){

        if (sonidoDisparo != null) { 
            sonidoDisparo.Play();
        }
        rb=GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * velocidad;
        Destroy(gameObject, tiempoVida);
    }
    private void OnTriggerEnter2D(Collider2D collision){

        if (colorTags.Contains(collision.tag)) {

            if (sonidoExplosion != null){

                sonidoExplosion.Play();

                Datos.Instance.AddPoints(collision.gameObject.GetComponent<EnemyMove>().puntos);
                Datos.Instance.MostrarPuntosDinamicos(collision.gameObject.GetComponent<EnemyMove>().puntos, transform.position);
            }
            //sonidoExplosion.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject,3f);
        }
    }
}