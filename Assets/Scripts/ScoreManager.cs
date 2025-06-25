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
    int score = 0;
  
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

    void UpdateScoreText()
    {
        scoreText.text = $"{score} Pontos";
    }

    void UpdateHPText()
    {
        HPText.text = "HP " + Life + " ♥";
    }

}
