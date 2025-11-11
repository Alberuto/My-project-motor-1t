using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorGameManager2 : MonoBehaviour {

    public TextMeshProUGUI colorObjetivoText;
    public TextMeshProUGUI puntosText;
    public TextMeshProUGUI vidasText;
    public GameObject resultado;
    public TextMeshProUGUI textVictoria;
    public TextMeshProUGUI textDerrota;

    public string[] colorTags = { "Azul", "Rojo", "Rosa", "Verde", "Negro" };
    public int vidas = 3, puntos = 0;

    private string colorObjetivo;
    private List<string> coloresDisponibles;

    private void Start() {
        // Inicializa la lista de colores disponibles
        coloresDisponibles = new List<string>(colorTags);
        SiguienteColor();
    }
    public void SiguienteColor() {
        if (coloresDisponibles.Count == 0) {
            Debug.Log("No quedan colores disponibles.");
            return;
        }
        int idx = Random.Range(0, coloresDisponibles.Count);
        colorObjetivo = coloresDisponibles[idx];
        coloresDisponibles.RemoveAt(idx); // Elimina el color para que no se repita
        colorObjetivoText.text = "¡Toca un pájaro " + colorObjetivo + "!";
    }
    public bool ComprobarSeleccion(string tag) {
        return tag == colorObjetivo;
    }
    public void ActualizarUI() {
        vidasText.text = "vidas: " + vidas;
        puntosText.text = "puntuacion: " + puntos;

        if (puntos >= 5 || vidas <= 0) {
            resultado.SetActive(true);

            if (puntos >= 5){

                textVictoria.gameObject.SetActive(true);
                textDerrota.gameObject.SetActive(false);
            }
            else{
                textDerrota.gameObject.SetActive(true);
                textVictoria.gameObject.SetActive(false);

            }
        }
    }
    public void VolverAlMenu(){

        SceneManager.LoadScene("Menu");
    }
}