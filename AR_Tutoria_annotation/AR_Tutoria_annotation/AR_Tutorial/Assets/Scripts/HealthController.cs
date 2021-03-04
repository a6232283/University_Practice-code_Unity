using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthController : MonoBehaviour
{
    public static int health;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        health = 3;
    }

    //更新UI血量
    void Update()
    {
        text.text = "Health: " + health;
    }
}
