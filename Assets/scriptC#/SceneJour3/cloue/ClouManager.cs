using UnityEngine;

public class ClouManager : MonoBehaviour
{
    public Clou3 Clou;
    public Clou3 Clou2;
    public Clou3 Clou3;
    public Clou3 Clou4;
    public Animator panneauAnimator;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public bool isDone = false;
    public int clousPlacer = 0;

    private bool clou1DéjàPris = false;
    private bool clou2DéjàPris = false;
    private bool clou3DéjàPris = false;
    private bool clou4DéjàPris = false;

    public void CheckClou()
    {
        if (!clou1DéjàPris && Clou.estFini)
        {
            clousPlacer++;
            clou1DéjàPris = true;
        }

        if (!clou2DéjàPris && Clou2.estFini)
        {
            clousPlacer++;
            clou2DéjàPris = true;
        }

        if (!clou3DéjàPris && Clou3.estFini)
        {
            clousPlacer++;
            clou3DéjàPris = true;
        }

        if (!clou4DéjàPris && Clou4.estFini)
        {
            clousPlacer++;
            clou4DéjàPris = true;
        }

        if (clousPlacer == 4 && !isDone)
        {
            isDone = true;
            panneauAnimator.SetTrigger("LancerAnimation");

            if (audioSource != null && audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
