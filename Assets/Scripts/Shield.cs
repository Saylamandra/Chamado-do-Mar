using UnityEngine;

public class shield : MonoBehaviour
{
    public float lifetime = 3f; // Time before projectile is destroyed

    void Start()
    {
        Destroy(gameObject, lifetime); // Auto-destroy after some time
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Destroy on collision
    }
}