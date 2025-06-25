using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    int Life = 3;

    public int GetScore()
    {
        return score;
    }

    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    public int score = 0;
    public int money;
  
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateScoreText();
        UpdateHPText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

    }

    public void Update()
    {
        if (0 >= Life)
        {
                money = score / 10 + money;
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = $"{score} Pontos";
    }

    void UpdateHPText()
    {
        HPText.text = "HP " + Life + " ♥";
    }

}
