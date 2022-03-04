using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public GameObject pauseMenu;
	public GameObject deathScreen;

	public bool isPaused = false;
	public GameObject[] shipsObjs;
	public int shipIndex = 0;

	private void Awake()
	{
		if (Instance == null)
        {
			Instance = this;
			SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }
		else
        {
			Destroy(gameObject);
        }

		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;


		DontDestroyOnLoad(gameObject);
	}

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
		if (arg1.buildIndex == 0) return;

		var player = Instantiate(shipsObjs[shipIndex]);

		GameObject.FindGameObjectWithTag("VirtualCam").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = player.transform;

		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
		if(pauseMenu) pauseMenu.SetActive(false);

		deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
		if (deathScreen) deathScreen.SetActive(false);
    }

	public void TogglePause()
    {
		isPaused = !isPaused;
		pauseMenu.SetActive(isPaused);

		if(isPaused)
        {
			Time.timeScale = 0;
        }
		else
        {
			Time.timeScale = 1;
        }
	}

    public void PlayerDied ()
	{
		StartCoroutine(RestartGame());
	}

	IEnumerator RestartGame ()
	{
		Time.timeScale = .3f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;

		yield return new WaitForSecondsRealtime(2f);

		GameObject.FindGameObjectWithTag("Canvas")?.GetComponent<GameMenus>().OnPlayerDie();
		deathScreen.SetActive(true);
	}

}
