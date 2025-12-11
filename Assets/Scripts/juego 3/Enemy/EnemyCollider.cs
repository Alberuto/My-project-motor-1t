using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollider : MonoBehaviour{

    //[SerializeField] private float tiempoEspera;
    private PlayerMove playerMove;
    private PlayerAnimation playerAnimation;
    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoMorir;
    [SerializeField] private AudioSource sonidoDamage;

    public GameObject gameOverPanel;

    private VidasJugador playerLifes;
    private bool inmune = false;

    List<string> colorTags = new List<string> { "Rojo", "Azul", "Rosa", "Verde", "Negro", "Environment" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        playerMove = GetComponent<PlayerMove>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerLifes = GetComponent<VidasJugador>();
    }
    private void OnCollisionEnter2D(Collision2D other) {

        if (other.collider.CompareTag("Verde"))
            playerLifes.AddLives();

        if (colorTags.Contains(other.collider.tag)) {

                if (!inmune){
                playerLifes.RemoveLives();
                if (sonidoDamage != null) {
                    sonidoDamage.Play();
                }
                else {
                    Debug.LogError("sonidoDamage no asignado en el Inspector.");
                }
                StartCoroutine(ActivarInmunidad());
            }
            if (playerLifes.currentLives==0)
                StartCoroutine(PararYReiniciar());
        }
    }
    private IEnumerator PararYReiniciar() {

        gameOverPanel.SetActive(true);
        if (gameOverPanel != null) {
            gameOverPanel.SetActive(true);
        }
        else {
            Debug.LogError("Game Over Panel no asignado en el Inspector.");
        }
        if (sonidoMorir != null) {
            sonidoMorir.Play();
        }
        else {
            Debug.LogError("sonidoDamage no asignado en el Inspector.");
        }

        playerAnimation.AnimacionMuerte();
        playerMove.Parar();
        yield return new WaitForSecondsRealtime (3);
        Time.timeScale = 0;
        SceneManager.LoadScene("Portada");
    }
    private IEnumerator ActivarInmunidad(){

        inmune = true;
        yield return new WaitForSecondsRealtime(2);
        inmune = false;
    }
}