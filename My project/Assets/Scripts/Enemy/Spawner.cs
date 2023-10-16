using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private float _delay;

    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    [SerializeField] private Bird _bird;

    private WaitForSeconds _spawnWait;
    private Coroutine _spawning;

    private void Awake()
    {
        _spawnWait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _spawning = StartCoroutine(Spawning());

        foreach (Enemy enemy in _pool.Enemies)
            enemy.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        StopCoroutine(_spawning);

        foreach (Enemy enemy in _pool.Enemies)
            enemy.Died -= OnEnemyDied;
    }

    public void OnEnemyDied()
    {
        _bird.OnEnemyDied();
    }

    public void KillAll()
    {
        foreach (Enemy enemy in _pool.Enemies)
            enemy.gameObject.SetActive(false);
    }

    private IEnumerator Spawning()
    {
        yield return _spawnWait;

        Enemy enemy;
        if (_pool.TryGetEnemy(out enemy) == false)
            enemy = _pool.Instantiate(_prefab);

        enemy.transform.position = new Vector2(transform.position.x, Random.Range(_minPositionY, _maxPositionY));
        enemy.gameObject.SetActive(true);

        enemy.Died += OnEnemyDied;
        _spawning = StartCoroutine(Spawning());
    }
}
