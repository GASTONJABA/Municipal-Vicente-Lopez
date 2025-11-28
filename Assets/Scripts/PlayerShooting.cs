using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    
    private bool shootPressed;

    void Update()
    {
        if (shootPressed)
        {
            Shoot();
            shootPressed = false;
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody rb = bulletObj.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shootPressed = true;
        }
    }
}