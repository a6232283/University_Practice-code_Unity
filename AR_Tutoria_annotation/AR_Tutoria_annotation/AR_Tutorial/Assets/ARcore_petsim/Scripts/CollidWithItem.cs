using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidWithItem : MonoBehaviour
{
    private Animator DragonAnimator;

    void Start()
    {
        DragonAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}

