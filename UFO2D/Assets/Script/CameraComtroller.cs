using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComtroller : MonoBehaviour
{
    [Header("玩家物件")]
    public GameObject Player;

    [Header("相對位移")]
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LoteUpdate()
    {
        transform.position = Player.transform.position+offset;
    }
}
