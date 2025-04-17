using UnityEngine;

public class ChestToggle : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isOpen", false); // S'assurer que le coffre commence fermé
    }

    private void OnTriggerEnter(Collider other)
    {
        // Tu peux remplacer "Player" par le bon tag de ton joueur si besoin
        if (other.CompareTag("Player"))
        {
            isOpen = !isOpen; // Inverse l'état
            animator.SetBool("isOpen", isOpen);
        }
    }
}
