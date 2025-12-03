using UnityEngine;

public class AMRandom : MonoBehaviour {
    [Header("Puntos de patrulla")]
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;

    [Header("Velocidad y amplitud")]
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float amplitud = 0.5f;
    [SerializeField] private float frecuencia = 2f;

    [Header("Distancia mínima para cambiar de punto")]
    [SerializeField] private float distanciaCambio = 0.05f;

    private Transform[] waypoints;
    private SpriteRenderer sr;
    private int indiceActual = 0;
    private float tiempo = 0f;

    private void Start() {

        sr = GetComponent<SpriteRenderer>();
        waypoints = new Transform[2];

        if (puntoA == null) {
            GameObject a = new GameObject("PuntoA_" + name);
            a.transform.position = transform.position;
            puntoA = a.transform;
        }
        if (puntoB == null) {

            GameObject b = new GameObject("PuntoB_" + name);
            b.transform.position = transform.position + Vector3.right * 2f;
            puntoB = b.transform;
        }
        waypoints[0] = puntoA;
        waypoints[1] = puntoB;
        transform.position = waypoints[0].position;
        indiceActual = 1;
    }
    private void Update() {

        if (waypoints == null || waypoints.Length == 0) return;

        Vector2 destino = (Vector2)waypoints[indiceActual].position;
        Vector2 actual = transform.position;
        // Movimiento zigzag usando seno
        tiempo += Time.deltaTime * frecuencia;
        float offset = Mathf.Sin(tiempo) * amplitud;
        Vector2 nuevoPos = Vector2.MoveTowards(actual, destino, velocidad * Time.deltaTime);
        nuevoPos.y += offset;
        transform.position = nuevoPos;
        // Flip según la dirección
        Vector2 dir = destino - (Vector2)transform.position;
        ActualizarFlip(dir);

        // Cambiar de punto cuando llegue cerca
        if (Vector2.Distance(transform.position, destino) <= distanciaCambio) {

            indiceActual = (indiceActual == 0) ? 1 : 0;
            tiempo = 0f; // Reinicia el tiempo para el zigzag
        }
    }
    private void ActualizarFlip(Vector2 dir)    {
        if (sr == null) return;

        if (Mathf.Abs(dir.x) > 0.01f)
        {
            sr.flipX = dir.x < 0f;
        }
    }
}
