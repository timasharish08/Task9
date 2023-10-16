using UnityEngine;

public class BackroundMover : MonoBehaviour
{
    [SerializeField] private Background _prefab;
    [SerializeField] private int _count;

    [SerializeField] private float _betweenDistance;
    [SerializeField] private float _speed;

    private Background[] _backgrounds;
    private int _currentBackground;

    private void Awake()
    {
        _backgrounds = new Background[_count];
    }

    private void Start()
    {
        for (int i = 0; i < _backgrounds.Length; i++)
            _backgrounds[i] = Instantiate(_prefab, transform.position + Vector3.right * _betweenDistance * i, Quaternion.identity, transform);
    }

    private void Update()
    {
        foreach (Background background in _backgrounds)
            background.transform.position = Vector3.MoveTowards(background.transform.position, 
                new Vector3(-_betweenDistance, background.transform.position.y, 0), _speed * Time.deltaTime);

        if (_backgrounds[_currentBackground].transform.position.x <= -_betweenDistance)
        {
            _backgrounds[_currentBackground].transform.position = transform.position + Vector3.right * _betweenDistance * (_backgrounds.Length - 1);
            _currentBackground = ++_currentBackground % _backgrounds.Length;
        }
    }
}
