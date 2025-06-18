using UnityEngine;

public class SimpleBackAndForth : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float moveDistance = 3f;

    private Vector3 startPosition;
    private bool movingForward = true;
    private float currentOffset;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        currentOffset += (movingForward ? 1 : -1 ) * speed * Time.deltaTime;

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
                
        transform.position = startPosition + transform.forward * currentOffset;
    }
}