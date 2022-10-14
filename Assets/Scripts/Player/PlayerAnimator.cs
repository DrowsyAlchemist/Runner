using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string HitAnimation = "Hit";
    private const string DieAnimation = "Die";
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();    
    }

    public void PlayHit()
    {
        _animator.SetTrigger(HitAnimation);
    }

    public  void PlayDie()
    {
        _animator.SetTrigger(DieAnimation);
    }
}
