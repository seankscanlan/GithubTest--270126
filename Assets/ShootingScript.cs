using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate =.3f;

    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && timer >= fireRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
      Instantiate (bulletPrefab,firePoint.position, firePoint.rotation);
    }
}
