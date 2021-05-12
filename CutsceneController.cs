using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    private float speed = 3;
    public bool isMoving;
    public Conversation convo;
    public GameObject sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) 
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (convo.hadConversation)
        {
            StartCoroutine(EndCutscene());
        }
    }

    IEnumerator EndCutscene()
    {
        yield return new WaitForSeconds(.5f);
        // Load next scene
        sceneLoader.GetComponent<LoadNewArea>().LoadNextLevel();
    }
}
