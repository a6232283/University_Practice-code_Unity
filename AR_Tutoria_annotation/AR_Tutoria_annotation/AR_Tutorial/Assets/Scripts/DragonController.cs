
using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private DetectedPlane detectedPlane;

    public GameObject dragonPrefab;
    private GameObject dragonInstance;

    public GameObject pointer;
    public Camera firstPersonCamera;
    public float speed = 20f;

    void Update()
    {
        //如果還沒實例化噴火龍，關掉pointer並return
        if (dragonInstance == null || dragonInstance.activeSelf == false)
        {
            pointer.SetActive(false);
            return;
        }
        else
        {
            pointer.SetActive(true);
        }


        TrackableHit hitResult;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds;

        if (Frame.Raycast(Screen.width / 2, Screen.height / 2, raycastFilter, out hitResult))
        {
            //點擊位置
            Vector3 clickOn = hitResult.Pose.position;
            //將點擊位置的Y軸調成跟噴火龍一樣的位置
            clickOn.y = dragonInstance.transform.position.y;
            //將pointer的Y也調成跟噴火龍一樣的位置
            Vector3 pos = pointer.transform.position;
            pos.y = clickOn.y;
            pointer.transform.position = pos;

            //慢慢將pointer滑到點擊位置
            pointer.transform.position = Vector3.Lerp(pointer.transform.position, clickOn,
              Time.smoothDeltaTime * speed);
        }

        //噴火龍向pointer前近，在很近的時候放慢速度
        float dist = Vector3.Distance(pointer.transform.position,
            dragonInstance.transform.position) - 0.05f;
        if (dist < 0)
        {
            dist = 0;
        }

        Rigidbody rb = dragonInstance.GetComponent<Rigidbody>();
        rb.transform.LookAt(pointer.transform.position);
        rb.velocity = (dragonInstance.transform.localScale.x+0.0245f) *
            dragonInstance.transform.forward * dist / .01f;
    }

    //設置檢測到的plane
    public void SetPlane(DetectedPlane plane)
    {
        detectedPlane = plane;
        SpawnDragon();
    }

    //生成噴火龍
    void SpawnDragon()
    {
        if (dragonInstance != null)
        {
            DestroyImmediate(dragonInstance);
        }

        //
        Vector3 pos = detectedPlane.CenterPose.position;

        //生成噴火龍且受rigidbody的物理影響
        dragonInstance = Instantiate(dragonPrefab, pos,
                Quaternion.identity, transform);

        //生成噴火龍後增加 FoodConsumer和BombConsumer節點
        dragonInstance.AddComponent<FoodConsumer>();
        dragonInstance.AddComponent<BombConsumer>();
    }

}
