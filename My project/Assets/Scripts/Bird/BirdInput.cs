using UnityEngine;

[RequireComponent(typeof(BirdMover), typeof(Shooter))]
public class BirdInput : MonoBehaviour
{
    private BirdMover _mover;
    private Shooter _shooter;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _mover.Jump();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            _shooter.Shoot();
    }
}
