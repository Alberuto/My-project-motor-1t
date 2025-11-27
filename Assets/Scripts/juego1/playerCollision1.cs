using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision1 : MonoBehaviour {

    [SerializeField] private AudioClip sonidoError;
    [SerializeField] private AudioClip sonidoAcierto;

    public ColorGameManager colorManager; // Asignar en el inspector

    private void OnTriggerEnter2D(Collider2D other) {

        // Solo comprobar para los tags de pájaros
        if (System.Array.Exists(colorManager.colorTags, t => t == other.tag)) {

            if (colorManager.ComprobarSeleccion(other.tag)) {
                Debug.Log("¡Correcto! Era el color buscado: " + other.tag);
                Destroy(other.gameObject);
                colorManager.puntos++;
                colorManager.SiguienteColor();
                AudioManager.Instance.PlaySound(sonidoAcierto);
            }
            else {
                Debug.Log("¡Incorrecto! Ese no era el color pedido.");
                colorManager.vidas--;
                AudioManager.Instance.PlaySound(sonidoError);

                if (colorManager.vidas <= 0)
                    PararYReiniciar();
            }
            colorManager.ActualizarUI();
        }
    }
    private IEnumerator PararYReiniciar() {

        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1;
        SceneManager.LoadScene("Portada");
    }
}