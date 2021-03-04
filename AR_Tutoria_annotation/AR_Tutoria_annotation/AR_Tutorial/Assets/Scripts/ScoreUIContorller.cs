using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUIContorller : MonoBehaviour
{
    Text text;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        //更新UI分數
        score=ScoreboardController.score1;
        text.text = "Score: " + score;
    }
}
