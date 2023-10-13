using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    [SerializeField] private TextMeshProUGUI _scores;

    private void OnEnable()
    {
        _bird.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= OnScoreChanged;
    }

    public void OnScoreChanged()
    {
        _scores.text = _bird.Score.ToString();
    }
}
