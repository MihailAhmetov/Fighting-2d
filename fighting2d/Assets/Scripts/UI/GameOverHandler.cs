using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private Text _restartLabel;

    [HideInInspector] public bool GameOver;

    private void Update()
    {
        if (GameOver)
        {
            ShowRestartLabel();
            Restart();
        }
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            GameOver = false;
            HideRestartLabel();
        }
    }

    private void ShowRestartLabel()
    {
        _restartLabel.text = "Press R to restart";
    }

    private void HideRestartLabel()
    {
        _restartLabel.text = "";
    }
}
