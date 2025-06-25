using UnityEngine;

public class Colisor : MonoBehaviour
{
    //cria uma variavel

    public float EnemyLife = 5;

    [Header("Pontuação")]
    public int scoreValue = 10; 

    [Header("Divisão do inimigo")]
    public bool podeDividir = false;
    public GameObject prefablittleEnemy;
    public int quantidadeDividir = 0;

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisão detectada com " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("tiro") && !collision.gameObject.CompareTag("inimigotiro"))

        {
            EnemyLife -= 1;
            Debug.Log("Vida atual do inimigo: " + EnemyLife);

            if (EnemyLife <= 0)
            {
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.AddScore(scoreValue); // <<< Usa o valor configurado
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
        }
        else if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.GetComponent<HPManager>().ChangeLife(-1);
            Destroy(gameObject);
        }
    }
}
