using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLife : MonoBehaviour
{
    public int health;
    public ParticleSystem explosion;

    public void Hit(int damage)
    {
        health -= damage;

        if (health == 0)
            Death();
    }
  
    void Death()
    {
        ParticleSystem explosionEffect = Instantiate(explosion, transform.position, transform.rotation);
        explosionEffect.Play();

        Destroy(explosionEffect.gameObject, 1f);
        Destroy(gameObject);
    }
}
