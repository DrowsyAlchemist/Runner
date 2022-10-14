using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    public int Damage => _damage;
}
