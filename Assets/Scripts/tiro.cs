using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f; // Time before projectile is destroyed

    void Start()
    {
        Destroy(gameObject, lifetime); // Auto-destroy after some time
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Move forward
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Destroy on collision
    }
}