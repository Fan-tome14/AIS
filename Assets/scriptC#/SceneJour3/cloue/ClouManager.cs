using UnityEngine;

public class ClouManager : MonoBehaviour
{
    public Clou3 Clou;
    public Clou3 Clou2;
    public Clou3 Clou3;
    public Clou3 Clou4;
    public Animator panneauAnimator;

    public AudioSource audioSource; // Ajoute la référence à l'AudioSource
    public AudioClip audioClip;     // Ajoute la référence à l'AudioClip à jouer

    public bool isDone = false; // Indique si les vis du panneau sont placées

    public void CheckClou()
    {
        if (Clou.estFini && Clou2.estFini && Clou3.estFini && Clou4.estFini)
        {
            isDone = true; // Le panneau est réparé
            panneauAnimator.SetTrigger("LancerAnimation");

            // Lancer l'audio
            if (audioSource != null && audioClip != null)
            {
                audioSource.PlayOneShot(audioClip); // Joue l'audio
            }
        }
    }
}
