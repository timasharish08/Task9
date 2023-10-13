using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Update()
    {
        if (_panel.activeSelf && Input.anyKey)
            Hide();
    }

    public virtual void Show()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }

    public virtual void Hide()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }
}
