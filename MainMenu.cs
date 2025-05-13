using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
//MAINMENU

	public void StartMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
	}

	public void Options()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void OptionstoMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void Exit()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}

	public void ExittoMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
	}

	public void QuitGame()
	{
		Debug.Log("EXIT");
		Application.Quit();
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LevelCompletetoMenu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
	}
}
