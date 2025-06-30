using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public float speed = 3f;
    public float moveRange = 5f;
    public Rigidbody rbBoss;

    public GameObject bossProjectile;

    public float shootTimer = 0f;
    public float shootInterval = 2f;

    // Controle de investida
    public float chargeCooldown = 8f; // tempo entre investidas
    public float chargeDuration = 0.5f; // quanto tempo ele se move pra frente
    public float returnSpeed = 5f; // velocidade de deslizar de volta
    public float chargeForce = 10f; // velocidade da investida

    private float chargeTimer = 0f;
    private Vector3 startPos;
    private bool movingRight = true;
    [HideInInspector] public bool isCharging = false; // Tornar pública para acessar no Colisor
    private bool returning = false;

    void Start()
    {
        startPos = transform.position;
        shootTimer = Random.Range(0f, 1f);
        chargeTimer = chargeCooldown;
    }

    void Update()
    {
        if (returning)
        {
            ReturnToStart();
            return;
        }

        if (isCharging)
        {
            transform.Translate(Vector3.back * chargeForce * Time.deltaTime);
            return;
        }

        Move();

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            AtirarBoss();
            shootTimer = 0f;
        }

        chargeTimer -= Time.deltaTime;
        if (chargeTimer <= 0f)
        {
            StartCoroutine(ChargeAttack());
            chargeTimer = chargeCooldown;
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

    IEnumerator ChargeAttack()
    {
        isCharging = true;

        yield return new WaitForSeconds(chargeDuration);

        isCharging = false;
        returning = true;
    }

    void ReturnToStart()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPos, returnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, startPos) < 0.1f)
        {
            returning = false;
        }
    }
}
