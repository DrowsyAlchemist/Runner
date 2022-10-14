using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 1;

    public int HealthAmount => _healthAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            gameObject.SetActive(false);
    }
}
