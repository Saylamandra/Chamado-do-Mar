using UnityEngine;

public class Colisor : MonoBehaviour
{
    public float EnemyLife = 5;

    [Header("Pontuação")]
    public int scoreValue = 10;

    [Header("Divisão do inimigo")]
    public bool podeDividir = false;
    public GameObject prefablittleEnemy;
    public int quantidadeDividir = 0;

    [Header("Boss Settings")]
    public bool isBoss = false; // Marque essa opção no Inspector do boss
    private BossLifeSpawner lifeSpawner;

    private BossController bossController;

    void Start()
    {
        if (isBoss)
        {
            lifeSpawner = FindFirstObjectByType<BossLifeSpawner>();
            bossController = GetComponent<BossController>();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisão detectada com " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("tiro") && !collision.gameObject.CompareTag("inimigotiro"))
        {
            EnemyLife -= 1;
            Debug.Log("Vida atual do inimigo: " + EnemyLife);

            // Se for o boss, registrar o hit para o spawn de vida
            if (isBoss && lifeSpawner != null)
            {
                lifeSpawner.RegisterHit();
            }

            if (EnemyLife <= 0)
            {
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.AddScore(scoreValue);
                }

                // Divide em inimigos menores
                if (podeDividir && prefablittleEnemy != null)
                {
                    for (int i = 0; i < quantidadeDividir; i++)
                    {
                        Vector3 offset = Random.insideUnitSphere * 0.5f;
                        offset.y = 0;
                        Instantiate(prefablittleEnemy, transform.position + offset, Quaternion.identity);
                    }
                }

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("player"))
        {
            if (isBoss && bossController != null && bossController.isCharging)
            {
                // Hit kill na investida
                collision.gameObject.GetComponent<HPManager>().InstantKill();
            }
            else
            {
                // Dano normal no player
                collision.gameObject.GetComponent<HPManager>().ChangeLife(-1);

                // Se NÃO for o boss, destrói o inimigo
                if (!isBoss)
                {
                    Destroy(gameObject);
                }
            }
        }
        else if (collision.gameObject.CompareTag("shield"))
        {
            Destroy(gameObject);
        }
    }
}
