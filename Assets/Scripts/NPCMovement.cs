using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed = 2;

    private void Update()
    {
        transform.Translate(-1 * _horizontalSpeed * Time.deltaTime, 0, 0);
    }

    private void OnValidate()
    {
        if (_horizontalSpeed < 0)
            _horizontalSpeed *= -1;
    }
}
