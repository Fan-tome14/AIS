using UnityEngine;

public class GrabMusicPlayer : MonoBehaviour
{
    public AudioClip[] musicClips; // Les 4 musiques à glisser dans l'inspecteur
    private AudioSource audioSource;
    private int grabCount = 0;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.loop = false;
    }

    public void OnGrab()
    {
        if (musicClips.Length == 0) return;

        // Grab 5, 10, 15... => silence (ne rien faire)
        if (grabCount % (musicClips.Length + 1) == musicClips.Length)
        {
            // C'est le moment "silence", donc on arrête toute musique
            audioSource.Stop();
        }
        else
        {
            // On joue la musique correspondante
            int index = grabCount % (musicClips.Length + 1);
            audioSource.clip = musicClips[index];
            audioSource.Play();
        }

        grabCount++;
    }
}
