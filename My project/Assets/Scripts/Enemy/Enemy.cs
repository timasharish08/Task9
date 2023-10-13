using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Shooter))]
public class Enemy : Obstacle
{
    public event UnityAction Died;

    [SerializeField] private float _speed;

    [SerializeField] private float _delay;

    private Shooter _shooter;
    private float _reloadTime;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _reloadTime = _delay;
    }

    private void Update()
    {
        transform.Translate(-transform.right * _speed * Time.deltaTime);
        _reloadTime -= Time.deltaTime;

        if (_reloadTime <= 0)
        {
            _shooter.Shoot();
            _reloadTime = _delay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle obstacle))
            gameObject.SetActive(false);
    }

    public virtual void TakeDamage()
    {
        gameObject.SetActive(false);
        Died?.Invoke();
    }
}
