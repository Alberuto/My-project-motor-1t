using UnityEngine;

public class playerCollision2 : MonoBehaviour {

    public ColorGameManager2 colorManager; // Asignar en el inspector

    private void OnTriggerEnter2D(Collider2D other) {

        // Solo comprobar para los tags de pájaros
        if (System.Array.Exists(colorManager.colorTags, t => t == other.tag)) {

            if (colorManager.ComprobarSeleccion(other.tag)) {
                Debug.Log("¡Correcto! Era el color buscado: " + other.tag);
                Destroy(other.gameObject);
                colorManager.puntos++;
                colorManager.SiguienteColor();
            }
            else {
                Debug.Log("¡Incorrecto! Ese no era el color pedido.");
                colorManager.vidas--;
            }
            colorManager.ActualizarUI();
        }
    }
}