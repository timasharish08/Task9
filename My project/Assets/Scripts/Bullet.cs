using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
            Destroy(gameObject);
    }
}
