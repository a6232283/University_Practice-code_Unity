using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    public Text scoreText;

    int score;

    Rigidbody2D ballRigidbody2D;


    CircleCollider2D ballCircleCollider2D;

    [Header("水平速度")]
    public float speedX;
    
    [Header("垂直速度")]
    public float speedY;

    enum tags
    {
        磚塊,
        背景
    }

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody2D = GetComponent<Rigidbody2D>();
        //ballRigidbody2D .velocity = new Vector2(speedX, speedY);
        ballCircleCollider2D = GetComponent < CircleCollider2D >();
        Invoke("ballStar", 3);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        lockSpeed();
        if (other.gameObject.CompareTag(tags.磚塊.ToString()))
        {
            other.gameObject.SetActive(false);
            score += 10;
            scoreText.text = "分數：" + score;
        }
    }


    void lockSpeed()
    {
        Vector2 lockSpeed = new Vector2(resetSpeedX(), resetSpeedY());
        ballRigidbody2D.velocity = lockSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&&isStop())
        {
            ballStar();
        }
    }

    void ballStar()
    {
        if (isStop())
        {
        ballCircleCollider2D.enabled = true;
        transform.SetParent(null);
        ballRigidbody2D.velocity = new Vector2(speedX, speedY);
        }
        
    }
    bool isStop()
    {
        return ballRigidbody2D.velocity == Vector2.zero;
    }

    float resetSpeedX()
    {
        float currentSpeedX = ballRigidbody2D.velocity.x;
        if (currentSpeedX < 0)
        {
            return -speedX;
        }
        else
        {
            return speedX;
        }
    }

    float resetSpeedY()
        {
            float currentSpeedY = ballRigidbody2D.velocity.y;
            if (currentSpeedY < 0)
            {
                return -speedY;
            }
            else
            {
                return speedY;
            }

        }
}
