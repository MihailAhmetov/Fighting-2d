using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPdisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _hpDisplay;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _hpDisplay.text = health.ToString();
    }
}
