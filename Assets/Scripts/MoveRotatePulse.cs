using UnityEngine;

public class MoveRotatePulse : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float _scaleSpeed = 0.7f;
    [SerializeField] private float _maxScale = 1.5f;
    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _rotationSpeed = 1.0f;

    private Vector3 startPosition;
    private Vector3 _startScale;
    private Vector3 _direction = Vector3.up;
    private float currentOffset;
    private float _currentProgress;
    private bool movingForward = true;
    private bool _isGrowing = true;

    private void Start()
    {
        startPosition = transform.position;
        _startScale = transform.localScale;
    }

    private void Update()
    {
        currentOffset += (movingForward ? 1 : -1) * speed * Time.deltaTime;
        _currentProgress += (_isGrowing ? 1 : -1) * _scaleSpeed * Time.deltaTime;

        if (currentOffset >= moveDistance)
        {
            currentOffset = moveDistance;
            movingForward = false;
        }
        else if (currentOffset <= 0f)
        {
            currentOffset = 0f;
            movingForward = true;
        }

        if (_currentProgress >= 1f)
        {
            _currentProgress = 1f;
            _isGrowing = false;
        }
        else if (_currentProgress <= 0f)
        {
            _currentProgress = 0f;
            _isGrowing = true;
        }

        transform.Rotate(_direction, _rotationSpeed);
        transform.localPosition = startPosition + transform.forward * currentOffset;
        float currentMultiplier = _minScale + (_maxScale - _minScale) * _currentProgress;
        transform.localScale = _startScale * currentMultiplier;
    }


}