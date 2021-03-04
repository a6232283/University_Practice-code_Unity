using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//全都自己打
public class Score : MonoBehaviour
{
    public static int score=0;        // 玩家的分數
    public Text score_text;              // 畫面分數   
    
    void Awake()
    {
        score_text = GetComponent<Text>();
        score = 0;
    }


    void Update()
    {
        
         // 將顯示“ Score”，後跟得分值
        score_text.text =score.ToString();

        
    }
  
}
