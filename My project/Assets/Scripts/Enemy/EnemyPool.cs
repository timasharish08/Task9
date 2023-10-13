using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private List<Enemy> _enemies;

    public Enemy[] Enemies => _enemies.ToArray();

    private void Awake()
    {
        _enemies = new List<Enemy>();
    }

    public Enemy Instantiate(Enemy prefab)
    {
        Enemy entity = Instantiate(prefab, transform);
        _enemies.Add(entity);

        return entity;
    }

    public bool TryGetEnemy(out Enemy result)
    {
        result = _enemies.FirstOrDefault(entity => entity.gameObject.activeSelf == false);

        return result != null;
    }
}
