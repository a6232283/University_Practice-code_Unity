using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAndCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D" + name + "碰到了" + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D" + name + "觸發了" + collision.gameObject.name);
    }
}
