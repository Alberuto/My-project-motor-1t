using UnityEngine;
using UnityEngine.UI;

public class IntroCanvasManager : MonoBehaviour {

    public GameObject introCanvas; // Asigna el Canvas en el inspector

    void Start() {

        introCanvas.SetActive(true); // Muestra el Canvas al empezar
    }
    public void EmpezarNivel() {

        introCanvas.SetActive(false); // Oculta el Canvas y comienza el nivel
    }
}