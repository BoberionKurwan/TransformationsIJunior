using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed = 0.7f;
    [SerializeField] private float _maxScale = 1.5f;
    [SerializeField] private float _minScale = 0.5f;

    private Vector3 _startScale;
    private float _currentProgress;
    private bool _isGrowing = true;
    
    private void Start()
    {
        _startScale = transform.localScale;
    }

    private void Update()
    {
        _currentProgress += (_isGrowing ? 1 : -1) * _scaleSpeed * Time.deltaTime;

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

        float currentMultiplier = _minScale + (_maxScale - _minScale) * _currentProgress;
        transform.localScale = _startScale * currentMultiplier;
    }
}
