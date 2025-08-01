using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        ScoreHandler.OnScoreChanged += ScoreHandler_OnOnScoreChanged;
    }
    
    private void OnDestroy()
    {
        ScoreHandler.OnScoreChanged -= ScoreHandler_OnOnScoreChanged;
    }

    private void ScoreHandler_OnOnScoreChanged(int score)
    {
        scoreText.text = score.ToString();
    }
}