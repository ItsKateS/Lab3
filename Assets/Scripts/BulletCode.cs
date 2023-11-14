using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    float life = 3f;

    private void Awake()
    {
        Destroy(gameObject, life);
    }
}
