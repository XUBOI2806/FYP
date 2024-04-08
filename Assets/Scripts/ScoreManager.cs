using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    public static int score = 0; // To keep track of the score

    void Start()
    {
        UpdateScoreText(); // Initial score display
    }

    // Call this method every time a successful shot is made
    public void IncrementScore()
    {
        score++; // Increase the score by 1
        UpdateScoreText(); // Update the UI text
    }

    // Updates the score display
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}