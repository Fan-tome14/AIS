using System.Collections; // <= CECI EST NÉCESSAIRE POUR IEnumerator
using UnityEngine;

public class AudioSequence : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        yield return new WaitForSeconds(1f);

        audioSource1.Play();

        
        yield return new WaitForSeconds(audioSource1.clip.length);
        audioSource2.Play();
    }
}
