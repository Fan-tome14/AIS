using UnityEngine;
using UnityEngine.InputSystem;

public class LaserShooter : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform shootOrigin;
    public float shootForce = 20f;
    public InputActionProperty shootAction;

    private bool canShoot = false;

    void OnEnable()
    {
        shootAction.action.performed += OnShootButtonPressed;
        shootAction.action.Enable(); // Assure que l'action est active
    }

    void OnDisable()
    {
        shootAction.action.performed -= OnShootButtonPressed;
        shootAction.action.Disable();
    }

    private void OnShootButtonPressed(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, shootOrigin.position, shootOrigin.rotation);
        Rigidbody rb = laser.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = shootOrigin.forward * shootForce;
        }
    }

    public void EnableShootingForOneMinute()
    {
        canShoot = true;
        Invoke(nameof(DisableShooting), 60f);
    }

    void DisableShooting()
    {
        canShoot = false;
    }
}
