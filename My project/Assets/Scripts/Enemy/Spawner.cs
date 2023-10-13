using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private float _delay;

    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    [SerializeField] private Bird _bird;

    private float _spawnTime;

    private void Awake()
    {
        _spawnTime = _delay;
    }

    private void OnEnable()
    {
        foreach (Enemy enemy in _pool.Enemies)
            enemy.Died += OnEnemyDied;
    }

    private void Update()
    {
        _spawnTime -= Time.deltaTime;

        if (_spawnTime <= 0)
        {
            Spawn();
            _spawnTime = _delay;
        }
    }

    private void OnDisable()
    {
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

    private void Spawn()
    {
        Enemy enemy;

        if (_pool.TryGetEnemy(out enemy) == false)
            enemy = _pool.Instantiate(_prefab);

        enemy.transform.position = new Vector2(transform.position.x, Random.Range(_minPositionY, _maxPositionY));
        enemy.gameObject.SetActive(true);
        enemy.Died += OnEnemyDied;
    }
}
