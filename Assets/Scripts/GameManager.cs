using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public bool isPaused = false;
	public GameObject[] shipsObjs;
	public int shipIndex = 0;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;

		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

		DontDestroyOnLoad(gameObject);
	}

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
		if (arg1.buildIndex == 0) return;

		var player = Instantiate(shipsObjs[shipIndex]);

		GameObject.FindGameObjectWithTag("VirtualCam").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = player.transform;
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

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
