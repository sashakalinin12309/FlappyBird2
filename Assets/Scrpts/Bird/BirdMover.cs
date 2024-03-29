using System.Collections;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _hightJump = 2;
    [SerializeField] private float _minAngle =  -45f;
    [SerializeField] private float _maxAngle = 45f;
    [SerializeField] private float _speedRotation = 2f;

    public void Jump()
    {
        Vector2 currentSpeed = _rigidbody2D.velocity;
        float startSpeed = Mathf.Sqrt(_hightJump * 2 * Mathf.Abs(Physics.gravity.y));
        _rigidbody2D.velocity = new Vector2(currentSpeed.x,0);
        _rigidbody2D.AddForce(new Vector2(0, startSpeed * _rigidbody2D.mass), ForceMode2D.Impulse);
        Rotate();
    }

    private void Awake()
    {
        _rigidbody2D.velocity = new Vector2(_speed, 0);
    }

    private void Update()
    {
        _rigidbody2D.rotation = Mathf.Lerp(_rigidbody2D.rotation, _maxAngle, Time.deltaTime * _speedRotation);
    }

    private void Rotate()
    {
        _rigidbody2D.rotation = _minAngle;
    }

}
