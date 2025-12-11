using UnityEngine;

public class RockSpawner : MonoBehaviour {

    public GameObject rockPrefab;

    [Header("Rango de X donde puede caer")]
    public float minXOffset = -1.5f;
    public float maxXOffset = 1.5f;

    [Header("Tiempos entre rocas")]
    public float minDelay = 3f;
    public float maxDelay = 9f;

    [Header("Velocidad / gravedad")]
    public float minGravityScale = 0.5f;
    public float maxGravityScale = 1.5f;
    public float minExtraDownForce = 0f;
    public float maxExtraDownForce = 1f;

    private void Start() {
        StartCoroutine(SpawnLoop());
    }
    private System.Collections.IEnumerator SpawnLoop() {
        while (true) {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            SpawnRock();
        }
    }
    private void SpawnRock() {

        // Posici�n aleatoria en X alrededor del spawner
        float xOffset = Random.Range(minXOffset, maxXOffset);
        Vector3 spawnPos = transform.position + new Vector3(xOffset, 0f, 0f);
        GameObject rock = Instantiate(rockPrefab, spawnPos, Quaternion.identity);
        // Aleatorizar gravedad / velocidad
        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();

        if (rb != null) {

            rb.gravityScale = Random.Range(minGravityScale, maxGravityScale);
            float extraDown = Random.Range(minExtraDownForce, maxExtraDownForce);
            rb.linearVelocity = new Vector2(0f, -extraDown);
        }
    }
}