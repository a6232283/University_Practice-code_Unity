using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyTrigger : MonoBehaviour
{
    public GameObject ParticleEffect;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void OnDestroy()
    {
        Instantiate(ParticleEffect, transform.position, transform.rotation);
    }
}
