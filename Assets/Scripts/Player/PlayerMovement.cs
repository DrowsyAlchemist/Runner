using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _verticalSpeed = 8;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    public bool TryMove(bool upDirection)
    {
        int direction = upDirection ? 1 : -1;
        float stepSize = direction * _verticalSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(0, stepSize);

        if (newPosition.y < _maxHeight && newPosition.y > _minHeight)
        {
            transform.position = newPosition;
            return true;
        }
        return false;
    }

    private void OnValidate()
    {
        if (_verticalSpeed < 0)
            _verticalSpeed *= -1;

        if (_maxHeight <= _minHeight)
            Debug.LogError("Invalid height constraints!");
    }
}
