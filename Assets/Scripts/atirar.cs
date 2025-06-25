using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign in Inspector
    public Transform spawnPoint; // Where the projectile spawns (e.g., gun barrel)
    public float shootForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Left-click or Fire input
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(
            projectilePrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        // Optional: Apply force (if using Rigidbody)
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnPoint.forward * shootForce, ForceMode.Impulse);
        }
    }
}