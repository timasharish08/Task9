using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public event UnityAction Died;
    public event UnityAction ScoreChanged;

    private Vector2 _startPosition;

    public int Score { get; private set; }

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            Died?.Invoke();
        }
    }

    public void OnEnemyDied()
    {
        Score++;
        ScoreChanged?.Invoke();
    }

    public void TakeDamage()
    {
        Died?.Invoke();
    }

    public void Restart()
    {
        transform.position = _startPosition;
        Score = 0;
        ScoreChanged?.Invoke();
    }
}
