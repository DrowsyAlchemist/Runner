using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private Player _player;
    private PlayerMovement _movement;

    private void Start()
    {
        _player = GetComponent<Player>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_player.IsAlive)
        {
            if (Input.GetKey(KeyCode.W))
                _movement.TryMove(upDirection: true);
            else if (Input.GetKey(KeyCode.S))
                _movement.TryMove(upDirection: false);
        }
    }
}
