using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;

    [SerializeField] Button[] shipSelectionButtons;
    [SerializeField] Sprite selectedShipSprite;
    [SerializeField] Sprite notSelectedShipSprite;

    public void OnPlayPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitPressed()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnSettingsPressed()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnBackPressed()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void OnSelectShipPressed(int i)
    {
        shipSelectionButtons[GameManager.Instance.shipIndex].image.sprite = notSelectedShipSprite;
        shipSelectionButtons[i].image.sprite = selectedShipSprite;

        GameManager.Instance.shipIndex = i;
    }
}
