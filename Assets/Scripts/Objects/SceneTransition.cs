using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    [Header("New Scene Variables")]
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public VectorValue cameraMin;
    public VectorValue cameraMax;
    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;

    [Header("Transition Variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOut;
    public float fadeWait;

    private void Awake(){
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    public void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && !other.isTrigger){
            playerStorage.initialValue = playerPosition;
            //SceneManager.LoadScene(sceneToLoad);
            StartCoroutine(FadeCo());


        }
    }

    public IEnumerator FadeCo(){
        if (fadeOut != null)
        {
            Instantiate(fadeOut, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        ResetCameraBounds();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone){
            yield return null;
        }
    }

    public void ResetCameraBounds(){
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;

    }
}
