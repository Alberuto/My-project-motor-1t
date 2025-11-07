using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public GameObject helpCanvas; // Asignar el Canvas de ayuda desde el Inspector
    public GameObject uiCanvas;   // Canvas principal UI


    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Help")) {

            helpCanvas.SetActive(true);
            uiCanvas.SetActive(false);
        }
        else if (other.CompareTag("Level1")) {

            SceneManager.LoadScene("Juego 1");
        }
        else if (other.CompareTag("Level2")) {

            SceneManager.LoadScene("Juego 2");
        }
    }
    public void CloseHelpCanvas() {
        helpCanvas.SetActive(false);
        uiCanvas.SetActive(true);
    }

}