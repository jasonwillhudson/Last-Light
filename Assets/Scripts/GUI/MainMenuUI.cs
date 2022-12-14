using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private void Start()
    {
        // Play Music
        MusicManager.Instance.PlayMusic(GameResources.Instance.mainMenuMusic, 0f, 2f);
    }

    /// <summary>
    /// Called from the Play Game / Enter The Dungeon Button
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("InstructioScene");
    }
}
