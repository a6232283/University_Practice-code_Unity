using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform trage;
    public float smoothing = 5f;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - trage.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = trage.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
