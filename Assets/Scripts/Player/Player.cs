using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent((typeof(Collider2D)))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private float _dieDelay = 1;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private PlayerAnimator _animator;

    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public bool IsAlive { get; private set; } = true;

    private void Start()
    {
        _animator = GetComponent<PlayerAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsAlive)
        {
            if (collision.TryGetComponent(out Enemy enemy))
                HitByEnemy(enemy);
            else if (collision.TryGetComponent(out Healer healer))
                HealByHealer(healer);
        }
    }

    private void HitByEnemy(Enemy enemy)
    {
        _animator.PlayHit();
        _health -= enemy.Damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            StartCoroutine(Die());
    }

    private void HealByHealer(Healer healer)
    {
        _health += healer.HealthAmount;

        if (_health > _maxHealth)
            _health = _maxHealth;
        else
            HealthChanged?.Invoke(_health);
    }


    private IEnumerator Die()
    {
        IsAlive = false;
        _animator.PlayDie();
        yield return new WaitForSeconds(_dieDelay);
        gameObject.SetActive(false);
        Died?.Invoke();
    }

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
