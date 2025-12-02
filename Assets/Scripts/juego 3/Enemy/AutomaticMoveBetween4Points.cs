using UnityEngine;

public class AutomaticMoveBetween4Points : MonoBehaviour{

    [Header("Waypoints en orden (rectángulo)")]
    [SerializeField] private Transform[] waypoints;   // 0,1,2,3 = esquinas

    [Header("Velocidad")]
    [SerializeField] private float velocidad = 2f;

    [Header("Distancia mínima para cambiar de punto")]
    [SerializeField] private float distanciaCambio = 0.05f;

    private int indiceActual = 0;
    private SpriteRenderer sr; // Añadido

    private void Start() {

        sr = GetComponent<SpriteRenderer>(); // Añadido

        // Si no has asignado waypoints, crear al menos uno en la posición inicial
        if (waypoints == null || waypoints.Length == 0) {

            GameObject p = new GameObject("Punto_0_" + name);
            p.transform.position = transform.position;
            waypoints = new Transform[1];
            waypoints[0] = p.transform;
        }
        // Opcional: coloca al enemigo en el primer waypoint
        transform.position = waypoints[0].position;
    }
    void Update() {
        if (waypoints.Length == 0) return;

        Transform destinoTransform = waypoints[indiceActual];
        Vector2 destino = destinoTransform.position;
        Vector2 actual = transform.position;

        // Mover hacia el waypoint actual
        transform.position = Vector2.MoveTowards(actual, destino, velocidad * Time.deltaTime);

        // Cuando esté suficientemente cerca, pasar al siguiente
        if (Vector2.Distance(transform.position, destino) <= distanciaCambio) {
            int indiceAnterior = indiceActual; // Añadido

            indiceActual++;
            if (indiceActual >= waypoints.Length) {
                indiceActual = 0; // volver al primero para hacer un bucle
            }
            // Calcular la dirección del siguiente tramo
            Vector2 siguienteDir = (Vector2)waypoints[indiceActual].position - (Vector2)waypoints[indiceAnterior].position;
            if (sr != null) {
                // Flip en X según la dirección horizontal
                sr.flipX = siguienteDir.x < 0f;
            }
        }
    }
}