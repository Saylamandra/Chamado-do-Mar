using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    float tempodevida = 5f;
    float timerdevida = 0f;
    Rigidbody rbProjectile;
    public float forceAmount = -2500f;

    private bool hasHit = false; // Flag pra impedir múltiplos hits

    void Start()
    {
        rbProjectile = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timerdevida += Time.deltaTime;
        if (timerdevida > tempodevida)
        {
            Destroy(gameObject);
        }

        rbProjectile.AddForce(transform.forward * forceAmount * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return; // Impede múltiplos hits no mesmo frame

        if (collision.gameObject.CompareTag("player"))
        {
            hasHit = true; // Marca que já acertou

            collision.gameObject.GetComponent<HPManager>().ChangeLife(-1);

            Destroy(gameObject);
        }
    }
}
