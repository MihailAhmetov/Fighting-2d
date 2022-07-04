using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private int _health = 100;

    private Animator _animator;
    private GameOverHandler _gameOverHandler;

    public bool WasdPlayer { get; private set; }
    public event UnityAction<int> HealthChanged;
    private void Start()
    {
        HealthChanged?.Invoke(_health);

        _animator = GetComponent<Animator>();
        _gameOverHandler = FindObjectOfType<GameOverHandler>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        _animator.SetTrigger("Hurt");

        if (_health <= 0)
            StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        _animator.SetTrigger("Die");
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
        _gameOverHandler.GameOver = true;
    }
}
