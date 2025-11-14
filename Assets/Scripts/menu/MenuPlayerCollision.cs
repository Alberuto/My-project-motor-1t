using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public GameObject helpCanvas; // Asignar el Canvas de ayuda desde el Inspector
    public GameObject uiCanvas;   // Canvas principal UI

    [SerializeField] private AudioClip sonidoJuegos;
    [SerializeField] private AudioClip sonidoAyuda;
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Help")) {

            AudioManager.Instance.PlaySound(sonidoAyuda);
            helpCanvas.SetActive(true);
            uiCanvas.SetActive(false);
        }
        else if (other.CompareTag("Level1")) {

            AudioManager.Instance.PlaySound(sonidoJuegos);
            SceneManager.LoadScene("Juego 1");
        }
        else if (other.CompareTag("Level2")) {

            AudioManager.Instance.PlaySound(sonidoJuegos);
            SceneManager.LoadScene("Juego 2");
        }
        else if (other.CompareTag("Level3")) {

            AudioManager.Instance.PlaySound(sonidoJuegos);
            SceneManager.LoadScene("Juego 3");
        }
    }
    public void CloseHelpCanvas() {
        helpCanvas.SetActive(false);
        uiCanvas.SetActive(true);
    }
}