using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenus : MonoBehaviour
{
    public TMP_Text gameOverScoreTxt;

    public void OnPlayPressed()
    {
        GameManager.Instance.TogglePause();
    }

    public void OnQuitPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPlayerDie()
    {
        gameOverScoreTxt.text = $"YOUR FINAL SCORE WAS: {Progression.Score}";
    }
}
