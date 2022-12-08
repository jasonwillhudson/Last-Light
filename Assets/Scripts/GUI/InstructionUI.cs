using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionUI : MonoBehaviour
{
    public string enterScene;

    public string backToMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Play Music
        MusicManager.Instance.PlayMusic(GameResources.Instance.mainMenuMusic, 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterGame()
    {
        SceneManager.LoadScene(enterScene);
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene(backToMainMenu);
    }
}
