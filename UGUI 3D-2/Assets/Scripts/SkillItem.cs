using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    public float coldTime = 2;//技能冷卻時間
    private float timer = 0;//計時器初始
    private Image filledImage;
    private bool isStarTime;//開始計算時間
    public KeyCode keyCode;
    // Start is called before the first frame update
    void Start()
    {
        filledImage = transform.Find("FilledSkill").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            isStarTime = true;
        }
        if(isStarTime)
        {
            timer += Time.deltaTime;
            filledImage.fillAmount = (coldTime - timer) / coldTime;
        }
        if(timer >=coldTime)
        {
            filledImage.fillAmount = 0;
            timer = 0;
            isStarTime = false;
        }
    }
    public void OnClick()
    {
        isStarTime = true;
    }
}
