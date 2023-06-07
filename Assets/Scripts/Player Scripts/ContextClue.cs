using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;
    public bool contextActive;

    public void ChangeContext(){
        contextActive = !contextActive;
        if (contextActive)
        {
            contextClue.SetActive(true);
        }else{
            contextClue.SetActive(false);
        }
    }
    // Start is called before the first frame update
    public void Enable(){
        contextClue.SetActive(true);
    }

    public void Disable(){
        contextClue.SetActive(false);
    }
}
 