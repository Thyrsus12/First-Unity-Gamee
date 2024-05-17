using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public GameObject uiLoad;
    public Image uiBar;

    public void NewGameButton()
    {
        StartCoroutine("load");
    }

    public IEnumerator load()
    {
        uiLoad.SetActive(true);
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        while (!sceneLoad.isDone) 
        {
            uiBar.fillAmount = sceneLoad.progress;
            yield return null;
        }
    }
}
