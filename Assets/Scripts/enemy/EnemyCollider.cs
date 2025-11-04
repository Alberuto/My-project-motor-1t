using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollider : MonoBehaviour{

    //[SerializeField] private float tiempoEspera;
    private playerMove playerMovement;
    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoMorir;
    [SerializeField] private AudioSource sonidoDamage;


    private bool inmune = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        playerMovement = GetComponent<playerMove>();

    }

    /*private void OnCollisionEnter2D(Collision2D other) {

        if (other.collider.CompareTag("Enemy")) {

                if (!inmune){
                    playerLifes.RemoveLives();
                    sonidoDamage.Play();
                }
                if (playerLifes.currentLives==0)
                    StartCoroutine(PararYReiniciar());
            }
            Debug.Log("asdf");
    }*/

    private IEnumerator PararYReiniciar() {

       // Time.timeScale = 0;
        sonidoMorir.Play();
 //       playerMovement.Parar();
        yield return new WaitForSecondsRealtime (5);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}