using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChangemin;
    public Vector2 cameraChangemax;
    public Vector3 playerChange;
    private CameraMovement cam;

    public bool needText;
    public string placeName;
    public GameObject text; 
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< Updated upstream
        if (other.CompareTag("Player"))
=======
        if (other.CompareTag("Player") && !other.isTrigger)
>>>>>>> Stashed changes
        {
            cam.minPosition += cameraChangemin;
            cam.maxPosition += cameraChangemax;
            other.transform.position += playerChange;
            if (needText) {
                StartCoroutine(placeNameCo());

            }
        }
    }

    private IEnumerator placeNameCo(){
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
