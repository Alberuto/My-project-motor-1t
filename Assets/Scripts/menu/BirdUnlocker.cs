using UnityEngine;

public class BirdUnlocker : MonoBehaviour {

    public GameObject birdPrefab; // Asigna el pájaro en el Inspector
    public GameObject textoPrefab; // Texto a mostrar/ocultar

    void Update() {
        ActualizarVisibilidad();
    }
    void ActualizarVisibilidad() {
        
        bool nivelesCompletados = PlayerPrefs.GetInt("Nivel1Completado") == 1 && PlayerPrefs.GetInt("Nivel2Completado") == 1;
        birdPrefab.SetActive(nivelesCompletados);
        textoPrefab.SetActive(nivelesCompletados);
    }
}