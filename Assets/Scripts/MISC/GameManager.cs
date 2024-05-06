using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;

    public GameObject mainMenu;
    public GameObject endMenu;
    public GameObject loseMenu;

    public PowerUpManager ppManager;
    private void Start()
    {
        player.enabled = false;
        ppManager.ResetPP();
        Time.timeScale = 1.0f;
        mainMenu.SetActive(true);
        endMenu.SetActive(false);
        loseMenu.SetActive(false);
    }
    public void Finish()
    {
        player.enabled = false;
        ppManager.ResetPP();
        Time.timeScale = 0.25f;
        mainMenu.SetActive(false);
        endMenu.SetActive(true);
        loseMenu.SetActive(false);
    }
    public void Lose()
    {
        player.enabled = false;
        ppManager.ResetPP();
        Time.timeScale = 0.25f;
        mainMenu.SetActive(false);
        endMenu.SetActive(false);
        loseMenu.SetActive(true);
    }
    public void Restart()
    {
        player.enabled = true;
        ppManager.ResetPP();
        Time.timeScale = 1.0f;
        mainMenu.SetActive(true);
        endMenu.SetActive(false);
        loseMenu.SetActive(false);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void StartGame()
    {
        player.enabled = true;
        ppManager.ResetPP();
        Time.timeScale = 1.0f;
        mainMenu.SetActive(false);
        endMenu.SetActive(false);
        loseMenu.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
