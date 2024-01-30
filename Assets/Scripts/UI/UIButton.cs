using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LoadSceneAfterDelayCoroutine());
    }

    // Update tvoji mamu
    public void Onclick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1"); ;

    }

    
    //žer hovna kemo
    IEnumerator LoadSceneAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnDick()
    {
        // You can still use this method without the delay if needed
        StartCoroutine(LoadSceneAfterDelayCoroutine());
    }
}
