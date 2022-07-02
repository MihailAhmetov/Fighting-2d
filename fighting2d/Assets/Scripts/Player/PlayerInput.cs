using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerAttacker))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;
    private Player _player;
    private PlayerAttacker _attacker;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _player = GetComponent<Player>();
        _attacker = GetComponent<PlayerAttacker>();
    }

    private void Update()
    {
        _mover.Move();
        JumpInput();
        AttackInput();
    }

    private void JumpInput()
    {
        if (_player.WasdPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
                _mover.Jump();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                _mover.Jump();
        }
    }

    private void AttackInput()
    {
        if (Time.time >= _attacker._nextAttackTime)
        {
            if (_player.WasdPlayer)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    _attacker.Attack();
                    _attacker._nextAttackTime = Time.time + 1f / _attacker._attackRate;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    _attacker.Attack();
                    _attacker._nextAttackTime = Time.time + 1f / _attacker._attackRate;
                }
            }
        }
    }
}
