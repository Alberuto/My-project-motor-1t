using UnityEngine;

public class AutomaticMoveBetween2PointsWithFlip : MonoBehaviour {

    [Header("Puntos de patrulla (2 puntos)")]
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;

    [Header("Velocidad")]
    [SerializeField] private float velocidad = 2f;

    [Header("Distancia mínima para cambiar de punto")]
    [SerializeField] private float distanciaCambio = 0.05f;

    private int indiceActual = 0;   // 0 = A, 1 = B
    private Transform[] waypoints;
    private SpriteRenderer sr;
    private void Start() {

        sr = GetComponent<SpriteRenderer>();

        // Configuramos el array de 2 puntos
        waypoints = new Transform[2];

        // Si no has asignado alguno, se crea en la posición actual
        if (puntoA == null) {

            GameObject a = new GameObject("PuntoA_" + name);
            a.transform.position = transform.position;
            puntoA = a.transform;
        }
        if (puntoB == null) {

            GameObject b = new GameObject("PuntoB_" + name);
            b.transform.position = transform.position + Vector3.right * 2f; // por ejemplo, 2 unidades a la derecha
            puntoB = b.transform;
        }
        waypoints[0] = puntoA;
        waypoints[1] = puntoB;
        // Empezar en A
        transform.position = waypoints[0].position;
        indiceActual = 1; // que vaya hacia B al inicio
        // Ajustar flip inicial según hacia dónde va
        ActualizarFlip(waypoints[indiceActual].position - transform.position);
    }
    void Update() {

        if (waypoints == null || waypoints.Length == 0) return;
        Transform destinoTransform = waypoints[indiceActual];
        Vector2 destino = destinoTransform.position;
        Vector2 actual = transform.position;
        // Mover hacia el waypoint actual
        transform.position = Vector2.MoveTowards(actual, destino, velocidad * Time.deltaTime);
        // Cuando esté suficientemente cerca, pasar al siguiente (A <-> B)
        if (Vector2.Distance(transform.position, destino) <= distanciaCambio) {

            int indiceAnterior = indiceActual;
            // Cambiar entre 0 y 1
            indiceActual = (indiceActual == 0) ? 1 : 0;
            // Dirección del siguiente tramo (para decidir flip)
            Vector2 siguienteDir = (Vector2)waypoints[indiceActual].position - (Vector2)waypoints[indiceAnterior].position;
            ActualizarFlip(siguienteDir);
        }
    }
    // Flip del sprite en el eje X según dirección
    private void ActualizarFlip(Vector2 dir) {
        if (sr == null) return;

        if (Mathf.Abs(dir.x) > 0.01f) {
            // Si se mueve a la izquierda, flipX = true; derecha, false
            sr.flipX = dir.x < 0f;
        }
    }
}
