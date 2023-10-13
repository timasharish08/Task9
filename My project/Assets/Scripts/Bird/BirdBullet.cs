using UnityEngine;

public class BirdBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage();
            Destroy(gameObject);
        }
        else if (collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
