using UnityEngine;

public class StartScreen : Screen
{
    [SerializeField] private ScoreCounter counter;

    private void Start()
    {
        Show();
    }

    public override void Hide()
    {
        counter.gameObject.SetActive(true);
        base.Hide();
    }
}
