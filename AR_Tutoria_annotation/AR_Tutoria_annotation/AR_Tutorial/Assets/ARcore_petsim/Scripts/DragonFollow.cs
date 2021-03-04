using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFollow : MonoBehaviour
{
    public string gameObjectTag;
    private GameObject objectToFollow;
    public float Speed = 2f;
    public float StoppingDistance = 1.0f;
    private Animator CatAnimator;
    // Start is called before the first frame update
    void Start()
    {
        //要跟蹤的物件
        objectToFollow = GameObject.FindGameObjectWithTag(gameObjectTag);
        CatAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (objectToFollow != null)
        {
            //將要跟蹤的物件的Y軸設置成跟噴火龍一樣的位置
            var tempPos = objectToFollow.transform.position;
            tempPos.y = transform.position.y;

            //當噴火龍跟玩家的距離大於停止距離，開始移動
            if (Vector3.Distance(transform.position, tempPos) > StoppingDistance)
            {
                //開始向玩家移動
                tempPos.y = -0.8f;
                transform.position = Vector3.MoveTowards(transform.position, tempPos, Speed * Time.deltaTime);

                //計算噴火龍旋轉位置
                var lookPos = objectToFollow.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                //慢慢轉向玩家
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
            }
        }
    }
}
