using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int                 CurrentScore { get; private set; }
    public int                 BestScore { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        BestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void AddScore(int points)
    {
        CurrentScore += points;

        if (CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
            PlayerPrefs.SetInt("BestScore", BestScore);
            PlayerPrefs.Save();
        }
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}