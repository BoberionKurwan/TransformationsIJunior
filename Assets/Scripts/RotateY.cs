using UnityEngine;

public class RotateY : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1.0f;

    private Vector3 _direction = Vector3.up;

    void Update()
    {
        transform.Rotate(_direction, _rotationSpeed);
    }
}
