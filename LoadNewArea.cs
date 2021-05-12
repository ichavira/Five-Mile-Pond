using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;
    public Animator transition;
    public float transitionTime = 1;
    public GameObject audioHolder;
    AudioManager audioMan;
    public bool destroyCurrentAudio;

    private void Start()
    {
        if (audioHolder != null)
        {
            audioMan = audioHolder.GetComponent<AudioManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        if (audioMan == null)
        {
            audioMan = GameObject.FindObjectOfType<AudioManager>();
        }
        audioMan.StopMusic();
        if (destroyCurrentAudio)
        {
            audioMan.DestroyHolder();
        }
        Scene currScene = SceneManager.GetActiveScene();
        StartCoroutine(LoadLevel(currScene.buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelName)
    {
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelName);
    }

}

