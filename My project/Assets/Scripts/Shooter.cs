using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;

    public void Shoot()
    {
        Instantiate(_prefab, transform.position, Quaternion.Euler(_prefab.transform.rotation.eulerAngles));
    }
}
