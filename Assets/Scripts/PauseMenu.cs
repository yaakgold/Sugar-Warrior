using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void OnPlayPressed()
    {
        GameManager.Instance.TogglePause();
    }

    public void OnQuitPressed()
    {
        SceneManager.LoadScene(0);
    }
}
