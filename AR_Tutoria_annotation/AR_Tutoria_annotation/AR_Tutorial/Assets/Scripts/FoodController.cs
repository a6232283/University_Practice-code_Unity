using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private DetectedPlane detectedPlane;
    private GameObject foodInstance;
    private float foodTime;
    private readonly float foodPeriod = 10f;

    public GameObject[] foodList;

    void Update()
    {
        //需有偵測到平面，才更新
        if (detectedPlane == null)
        {
            return;
        }

        if (detectedPlane.TrackingState != TrackingState.Tracking)
        {
            return;
        }

        //如果目前平面包含在其他平面，換成其他平面
        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }

        if (foodInstance == null || foodInstance.activeSelf == false)
        {
            if (ScoreboardController.score1 >= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    SpawnFoodInstance();
                }
                return;
            }
            else if (ScoreboardController.score1 >= 30)
            {
                for (int i = 0; i < 6; i++)
                {
                    SpawnFoodInstance();
                }
                return;

            }
            else if (ScoreboardController.score1 >= 60)
            {
                for (int i = 0; i < 12; i++)
                {
                    SpawnFoodInstance();
                }
                return;

            }
            else if (ScoreboardController.score1 >= 100)
            {
                for (int i = 0; i < 21; i++)
                {
                    SpawnFoodInstance();
                }
                return;

            }

            else if (ScoreboardController.score1 >= 150)
            {
                for (int i = 0; i < 33; i++)
                {
                    SpawnFoodInstance();
                }
                return;
            }

        }

        //食物經過一段時間沒吃就會消失
        foodTime += Time.deltaTime;
        if (foodTime >= foodPeriod)
        {
            Object.Destroy(foodInstance);
            foodInstance = null;
        }

        void SpawnFoodInstance()
        {

            //隨機選一個食物
            GameObject food = foodList[Random.Range(0, foodList.Length)];

            //*******************************************************

            //在平面的頂點隨機選擇一個位置，然後在頂點跟平面的中心選一個點
            List<Vector3> points = new List<Vector3>();
            detectedPlane.GetBoundaryPolygon(points);
            Vector3 point = points[Random.Range(0, points.Count)];
            float distance = Random.Range(0.05f, 1f);
            Vector3 foodPosition = Vector3.Lerp(point, detectedPlane.CenterPose.position, distance);

            //*******************************************************

            //將食物移動到平面上
            foodPosition.y += .05f;

            //設置anchor
            Anchor anchor = detectedPlane.CreateAnchor(new Pose(foodPosition, Quaternion.identity));
            //實例化食物
            foodInstance = Instantiate(food, foodPosition, Quaternion.identity,
                     anchor.transform);

            //初始化食物
            foodInstance.tag = "food";
            foodInstance.transform.localScale = new Vector3(.025f, .025f, .025f);
            foodInstance.transform.SetParent(anchor.transform);
            foodTime = 0;
            foodInstance.AddComponent<FoodSpecialEffect>();

        }
    }

    //設置平面
    public void SetClickedPlane(DetectedPlane clickedPlane)
    {
        detectedPlane = clickedPlane;
    }

}
