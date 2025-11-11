using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorGameManager : MonoBehaviour {

    public TextMeshProUGUI colorObjetivoText;
    public TextMeshProUGUI puntosText;
    public TextMeshProUGUI vidasText;
    public GameObject resultado;
    public TextMeshProUGUI textVictoria;
    public TextMeshProUGUI textDerrota;

    public string[] colorTags = { "Azul", "Rojo", "Rosa", "Verde", "Negro" };
    public int vidas = 3, puntos = 0;

    private string colorObjetivo; // Esta línea es clave
    private Dictionary<string, int> contadorColores = new Dictionary<string, int>();

    private void Start() {
        // Inicializa el contador para cada color
        foreach (string color in colorTags) {

            contadorColores[color] = 0;
        }
        SiguienteColor();
    }
    public void SiguienteColor() {

        var coloresDisponibles = colorTags.Where(c => contadorColores[c] < 2).ToArray();
        if (coloresDisponibles.Length == 0) {

            Debug.Log("Todos los colores han sido pedidos dos veces.");
            return;
        }

        int idx = Random.Range(0, coloresDisponibles.Length); // Cambiado aquí
        colorObjetivo = coloresDisponibles[idx];
        contadorColores[colorObjetivo]++;
        colorObjetivoText.text = "¡Toca un pájaro " + colorObjetivo + "!";
    }
    public bool ComprobarSeleccion(string tag) {

        return tag == colorObjetivo;
    }
    public void ActualizarUI() {

        vidasText.text = "vidas: " + vidas;
        puntosText.text = "puntuacion: " + puntos;

        if (puntos >= 10 || vidas <= 0) {

            resultado.SetActive(true);

            if (puntos >= 10){
                
                textVictoria.gameObject.SetActive(true);
                textDerrota.gameObject.SetActive(false);
            }
            else{

                textDerrota.gameObject.SetActive(true);
                textVictoria.gameObject.SetActive(false);
            }
        }
    }
    public void VolverAlMenu() {

        SceneManager.LoadScene("Menu");
    }
}