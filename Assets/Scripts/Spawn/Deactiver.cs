using UnityEngine;

public class Deactiver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.gameObject.SetActive(false);
        else if (collision.TryGetComponent(out Healer healer))
            healer.gameObject.SetActive(false);
    }
}
