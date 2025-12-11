using UnityEngine;

public class Rock : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.collider.CompareTag("Platform")) {

            Destroy(gameObject);
        }
    }
}