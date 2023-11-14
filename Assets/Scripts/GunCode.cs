using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunCode : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    float bulletSpeed = 10f;


    public int damage = 5;
    public float range = 1000f;

    float fireRate = 5f;
    float nextShot = 0f;

    public Camera camera_;
    public ParticleSystem flash;
    public ParticleSystem onHit;

    int score;
    public Text scoreText;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextShot)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            nextShot = Time.time + 1 / fireRate;
            flash.Play();
            Invoke(nameof(Shoot), 1f);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera_.transform.position, camera_.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Target"))
            {
                TargetLife target = hit.transform.GetComponent<TargetLife>();
                target.Hit(damage);
                score += damage;
                scoreText.text = "Score: " + score;
            }

            ParticleSystem hitEffect = Instantiate(onHit, hit.point, Quaternion.LookRotation(hit.normal));
            hitEffect.Play();

            Destroy(hitEffect.gameObject, 1f);
        }
    }
}
