using UnityEngine;

public class SimpleBackAndForth : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _moveDistance = 3f;

    private Vector3 _startPosition;
    private bool _movingForward = true;
    private float _currentOffset;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        _currentOffset += (_movingForward ? 1 : -1 ) * _speed * Time.deltaTime;

        if (_currentOffset >= _moveDistance)
        {
            _currentOffset = _moveDistance;
            _movingForward = false;
        }
        else if (_currentOffset <= 0f)
        {
            _currentOffset = 0f;
            _movingForward = true;
        }
                
        transform.position = _startPosition + transform.forward * _currentOffset;
    }
}