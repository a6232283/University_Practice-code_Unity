using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("水平移動速度")]
    public float speedX;
    Rigidbody2D playerRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveLefOrRight();
    }
    float LeftOrRight()
    {
        return Input.GetAxis("Horizontal");
    }
    void moveLefOrRight()
    {
        playerRigidbody2D.velocity= LeftOrRight() * new Vector2(speedX,0);
    }
}
