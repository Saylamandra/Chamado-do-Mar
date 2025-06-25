using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    private Rigidbody rb; // Referência pro Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pega o Rigidbody do inimigo
    }

 void FixedUpdate()
{
    if (player != null)
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        Vector3 direction = (targetPosition - transform.position);
        float distance = direction.magnitude;

        if (distance > 0.1f) // Se ainda está longe o suficiente
        {
            Vector3 moveDir = direction.normalized;
            rb.MovePosition(transform.position + moveDir * speed * Time.fixedDeltaTime);
        }
    }
}
}