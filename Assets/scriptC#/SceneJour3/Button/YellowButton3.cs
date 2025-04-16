using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;

public class YellowButton3 : MonoBehaviour
{
    public AudioSource soundbutton;
    public AudioSource casqueNonEquipeSound;
    public EquiperCasqueVR3 casqueVR;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Vector3 initialPosition;

    public List<GameObject> objectsToLift;
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();

    public float liftHeight = 2.5f;
    public float liftDuration = 3f;

    private bool objetsLeves = false;

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        initialPosition = transform.localPosition;

        foreach (GameObject obj in objectsToLift)
        {
            if (obj != null)
            {
                originalPositions[obj] = obj.transform.position;
            }
        }

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnButtonPressed);
            grabInteractable.hoverEntered.AddListener(OnHoverEntered);
        }
        else
        {
            Debug.LogError("⚠️ XRGrabInteractable manquant sur le bouton !");
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (casqueVR != null && casqueVR.estEquipe)
        {
            Debug.Log("🟢 Casque équipé ✅ - Bouton pressé.");

            if (soundbutton != null)
                soundbutton.Play();

            StartCoroutine(AnimateButtonPress());

            if (!objetsLeves)
                LiftObjectsSmoothly();
            else
                LowerObjectsSmoothly();

            objetsLeves = !objetsLeves;
        }
        else
        {
            Debug.LogWarning("❌ Casque non équipé - action bloquée.");

            if (casqueNonEquipeSound != null)
                casqueNonEquipeSound.Play();
            else
                Debug.LogWarning("🔇 Aucun son d'erreur assigné !");
        }
    }

    private void LiftObjectsSmoothly()
    {
        foreach (GameObject obj in objectsToLift)
        {
            if (obj != null)
            {
                Vector3 targetPos = originalPositions[obj] + new Vector3(0, liftHeight, 0);
                StartCoroutine(SmoothMove(obj, obj.transform.position, targetPos));
            }
        }
    }

    private void LowerObjectsSmoothly()
    {
        foreach (GameObject obj in objectsToLift)
        {
            if (obj != null && originalPositions.ContainsKey(obj))
            {
                StartCoroutine(SmoothMove(obj, obj.transform.position, originalPositions[obj]));
            }
        }
    }

    private IEnumerator SmoothMove(GameObject obj, Vector3 startPos, Vector3 endPos)
    {
        float elapsed = 0f;

        while (elapsed < liftDuration)
        {
            float t = elapsed / liftDuration;
            obj.transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = endPos;
    }

    private IEnumerator AnimateButtonPress()
    {
        transform.localPosition += new Vector3(0, -0.01f, 0);
        yield return new WaitForSeconds(0.2f);
        transform.localPosition = initialPosition;
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("🟡 Hover sur le bouton !");
    }
}
