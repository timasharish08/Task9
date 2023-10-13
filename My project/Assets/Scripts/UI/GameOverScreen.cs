using UnityEngine;

public class GameOverScreen : Screen
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _bird.Died += Show;
    }

    private void OnDisable()
    {
        _bird.Died -= Show;
    }

    public override void Show()
    {
        Bullet[] bullets = FindObjectsByType<Bullet>(FindObjectsSortMode.None);

        foreach (Bullet bullet in bullets)
            Destroy(bullet.gameObject);

        _spawner.KillAll();
        base.Show();
    }

    public override void Hide()
    {
        _bird.Restart();
        base.Hide();
    }
}
