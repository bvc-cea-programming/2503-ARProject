using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _speed;

    public void Initialize(Vector3 startPosition, Vector3 endPosition, float speed)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
        _speed = speed;
        transform.position = _startPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed * Time.deltaTime);

        if (transform.position == _endPosition)
        {
            Destroy(gameObject);
        }
    }
}