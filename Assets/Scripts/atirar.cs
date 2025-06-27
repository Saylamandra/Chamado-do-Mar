using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public GameObject projectilePrefab;  // Regular projectile (assigned in Inspector)
    public GameObject shieldPrefab;     // Shield projectile (assign a different prefab in Inspector)
    public Transform spawnPoint;        // Spawn location
    public float shootForce = 10f;      // Force applied to both projectiles
    public int shields = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Space = Regular projectile
        {
            audioManager.PlaySFX(audioManager.Shot);
            Shoot(projectilePrefab);
        }
        if (Input.GetKeyDown(KeyCode.E))    // E = Shield projectile
        {
            if (shields >= 1)
            {
                Shoot(shieldPrefab);
                shields = shields - 1;
            }
        }
    }

    // Generalized shooting method for both projectiles
    void Shoot(GameObject projectileToSpawn)
    {
        if (projectileToSpawn == null)
        {
            Debug.LogWarning("Projectile prefab not assigned!");
            return;
        }

        // Instantiate the projectile
        GameObject spawnedObject = Instantiate(
            projectileToSpawn,
            spawnPoint.position,
            spawnPoint.rotation
        );

        // Apply force (if Rigidbody exists)
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnPoint.forward * shootForce, ForceMode.Impulse);
        }
        if (projectileToSpawn == shieldPrefab)
        {
            // Make shield a child of the player
            spawnedObject.transform.parent = transform;

            Rigidbody shieldRb = spawnedObject.GetComponent<Rigidbody>();
            if (shieldRb != null)
            {
                shieldRb.isKinematic = true; // Disable physics
            }
        }
    }
}