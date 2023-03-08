using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{

public void play(){
    one.SetActive(false);
    three.SetActive(false);
    two.SetActive(false);
    please();


    
}  

public void please(){
    StartCoroutine(LoadSceneAsync(1));
}
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject LoadingScreen;
    public Slider slider;
    public float speed;
    IEnumerator LoadSceneAsync(int sceneId)
    {
        one.SetActive(false);
        three.SetActive(false);
        two.SetActive(false);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);
        
        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / speed);
            slider.value = progressValue;

            yield return null;
        }
    }
public void quit(){
    Application.Quit();
    Debug.Log("hi");
}
}
