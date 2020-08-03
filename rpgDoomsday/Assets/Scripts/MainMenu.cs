using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public GameObject optionsScreen, playOptions;
    public GameObject ButtonHolder;

    public GameObject loadingScreen, loadingIcon;
    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        //SceneManager.LoadScene(firstLevel);
        StartCoroutine(LoadStart());
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptionsPlay()
    {
        playOptions.SetActive(true);
        ButtonHolder.SetActive(false);
    }

    public void CloseOptionsPlay()
    {
        playOptions.SetActive(false);
        ButtonHolder.SetActive(true);
    }

    public IEnumerator LoadStart()
    {
        loadingScreen.SetActive(true);
        playOptions.SetActive(false);

        AsyncOperation asyncload = SceneManager.LoadSceneAsync(firstLevel);

        asyncload.allowSceneActivation = false;

        while (!asyncload.isDone)
        {
            if (asyncload.progress >= .9f)
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
