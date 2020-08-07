using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour
{
    public static LoadingScreenControl instance;
    public GameObject loadingScreenObj;
    public Slider slider;
    public GameObject mainmenu;

    AsyncOperation async;

    public void LoadScreenExample(int lvl) {
        
        instance = this;
        Debug.LogWarning("nr level " + lvl);
        StartCoroutine(LoadingScreen(lvl));
    }

    IEnumerator LoadingScreen(int lvl) {

        Debug.Log("am intrat si la scene=============");
        
        loadingScreenObj.SetActive(true);
        mainmenu.SetActive(false);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false) {
            Debug.Log("progress loading bar" + async.progress);
            slider.value = async.progress;
            if (async.progress == 0.9f) {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
