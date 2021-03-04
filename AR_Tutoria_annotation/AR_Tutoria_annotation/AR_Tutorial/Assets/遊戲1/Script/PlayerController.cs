using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;
//拿unity套件
public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;//呼叫搖桿
    public TouchField touchField;//旋轉UI
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();

        touchField = FindObjectOfType<TouchField>();
    }

    void Update()
    {
         var rb = GetComponent<Rigidbody>();
         //搖桿控制
         rb.velocity = new Vector3(joystick.Horizontal * 3f,rb.rotation.y,joystick.Vertical * 3f);

        //滑動右屏幕 旋轉
        transform.Rotate(Vector3.up, touchField.TouchDist.x);
    }

}

