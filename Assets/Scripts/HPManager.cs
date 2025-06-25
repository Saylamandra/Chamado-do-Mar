using UnityEngine;
using UnityEngine.UI; // necessário para Image
using TMPro;

public class HPManager : MonoBehaviour
{
    public TextMeshProUGUI HPText; // Arraste da UI aqui pelo inspetor
    public Image lifeBar;          // Arraste a Image da barra de vida aqui no inspetor

    int Life = 3;

    public int GetLife()
    {
        return Life;
    }

    private void Start()
    {
        UpdateHPDisplay();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisão detectada com: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("vida"))
        {
            ChangeLife(+1);
            Destroy(collision.gameObject);
        }
    }

    public void ChangeLife(int amount)
    {
        if (Life >= 3 && amount > 0)
            return; // não passa de 3 de vida

        Life += amount;

        if (Life > 3)
            Life = 3;

        UpdateHPDisplay();

        if (Life <= 0)
        {
            Debug.Log("Player morreu!");
            GameManager.Instance.TriggerGameOver();
            gameObject.SetActive(false);
        }
    }

    void UpdateHPDisplay()
    {
        if (HPText != null)
        {
            HPText.text = $"HP {Life} ♥";
        }

        if (lifeBar != null)
        {
            switch (Life)
            {
                case 3:
                    lifeBar.fillAmount = 1f;
                    break;
                case 2:
                    lifeBar.fillAmount = 0.675f;
                    break;
                case 1:
                    lifeBar.fillAmount = 0.333f;
                    break;
                case 0:
                    lifeBar.fillAmount = 0f;
                    break;
            }
        }
    }
}