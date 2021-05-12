using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource currAudioSrc;
    public float maxVolume;
    public bool continuePlaying;

    // Start is called before the first frame update

    private void Awake()
    { 
        currAudioSrc = gameObject.GetComponent<AudioSource>();
        StartCoroutine(FadeIn());
    }

    public void StopMusic()
    {
        if (continuePlaying)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            StartCoroutine(FadeOut());
            Destroy(gameObject);
        }
    }

    public void DestroyHolder()
    {
        Destroy(gameObject);
    }

    private IEnumerator FadeOut()
    {
        float speed = 0.01f;
        while (currAudioSrc.volume > 0)
        {
            currAudioSrc.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }

    }

    private IEnumerator FadeIn()
    {
        float speed = 0.005f;
        while (currAudioSrc.volume < maxVolume)
        {
            currAudioSrc.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
