using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionsScreen, pauseScreen, InfoImage;

    public string mainMenuScene;

    private bool isPaused;

    private bool escPressed;

    public GameObject loadingScreen, loadingIcon;
    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        escPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && escPressed == false)
        {
            PauseUnpause();
            escPressed = true;
        }
    }

    public void PauseUnpause()
    {
        if(!isPaused)
        {
            InfoImage.SetActive(false);
            pauseScreen.SetActive(true);
            isPaused = true;

            Time.timeScale = 0f;
        }
        else
        {
            InfoImage.SetActive(true);
            pauseScreen.SetActive(false);
            isPaused = false;
            escPressed = false;

            Time.timeScale = 1f;
        }
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitToMain()
    {
        //SceneManager.LoadScene(mainMenuScene);
        //Time.timeScale = 1f;

        StartCoroutine(LoadMain());
    }

    public IEnumerator LoadMain()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncload = SceneManager.LoadSceneAsync(mainMenuScene);

        asyncload.allowSceneActivation = false;

        while (!asyncload.isDone)
        {
            if(asyncload.progress >= .9f)
            {
                loadingText.text = "Press any key to continue";
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown)
                {
                    asyncload.allowSceneActivation = true;

                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }
    }
}
