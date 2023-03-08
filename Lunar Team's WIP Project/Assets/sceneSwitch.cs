using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneSwitch : MonoBehaviour
{


    public GameObject LoadingScreen;
    public Slider slider;
    public float speed;


    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);
        
        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / speed);
            slider.value = progressValue;

            yield return null;
        }
    }

 void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "PlayerCapsule"){
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
