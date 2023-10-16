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

    private WaitForSeconds _attackWait;
    private Coroutine _shooting;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _attackWait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _shooting = StartCoroutine(Shooting());
    }

    private void Update()
    {
        transform.Translate(-transform.right * _speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        StopCoroutine(_shooting);
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

    private IEnumerator Shooting()
    {
        yield return _attackWait;
        _shooter.Shoot();
        _shooting = StartCoroutine(Shooting());
    }
}
