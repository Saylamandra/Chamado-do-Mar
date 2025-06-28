using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed = 3f;
    public float moveRange = 5f;

    public Rigidbody rbBoss;

    public GameObject bossProjectile;

    public float shootTimer = 0f;
    public float shootInterval = 2f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
        shootTimer = Random.Range(0f, 1f);
    }

    void Update()
    {
        Move();

        // TIMER DE TIRO
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            AtirarBoss();
            shootTimer = 0f;
        }
    }

    void Move()
    {
        if (movingRight)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x > startPos.x + moveRange)
            movingRight = false;
        else if (transform.position.x < startPos.x - moveRange)
            movingRight = true;
    }

    void AtirarBoss()
    {
        Instantiate(bossProjectile, transform.position + new Vector3(0, 0, -1), transform.rotation);
    }
}
