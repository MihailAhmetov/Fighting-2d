using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;

    private Animator _animator;
    private Player _player;

    public float _attackRate;
    [HideInInspector] public float _nextAttackTime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _enemyLayer);

        foreach(Collider2D enemy in enemies)
            enemy.GetComponent<Player>().TakeDamage(20);
    }
}
