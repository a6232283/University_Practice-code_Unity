//-----------------------------------------------------------------------
//// <copyright file="GlobalScalable.cs" company="Google">
/////
///// Copyright 2017 Google Inc. All Rights Reserved.
/////
///// Licensed under the Apache License, Version 2.0 (the "License");
///// you may not use this file except in compliance with the License.
///// You may obtain a copy of the License at
/////
///// http://www.apache.org/licenses/LICENSE-2.0
/////
///// Unless required by applicable law or agreed to in writing, software
///// distributed under the License is distributed on an "AS IS" BASIS,
///// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
///// See the License for the specific language governing permissions and
///// limitations under the License.
/////
///// </copyright>
/////-----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component used to allow stretching or pinching to scale objects.
/// </summary>
/// <remarks>
/// This class has a static scale that affects all objects that
/// have this component enabled and the <code>adjustScale</code>
/// property is true.
/// <para>
/// The <code>handleScaleInput</code> property indicates that this instance
/// of the component should handle the touch events to update the scale factor.
/// Typically this is only enabled for on object per scene.
/// </para>
/// </remarks>
/// 

//**********************************************

public class GlobalScalable : MonoBehaviour
{

    private Vector3 originalScale;
    static private float scaleFactor = 1.0f;
    public bool handleScaleInput = false;
    public bool adjustScale = true;
    private float speed = 1f;

    void Start()
    {
        // 取得原始大小
        originalScale = transform.localScale;
    }
    void Update()
    {
        //如果可以處理輸入，尋找兩根手指手勢
        if (handleScaleInput)
        {
            if (Input.touchCount == 2)
            {
                //儲存兩根手指原始位置
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                //兩根手指前一幀位置
                Vector2 touchZeroPrevPos =
                    touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos =
                    touchOne.position - touchOne.deltaPosition;

                //前一幀兩根手指位置距離 
                float prevTouchDeltaMag =
                    (touchZeroPrevPos - touchOnePrevPos).magnitude;
                //兩根手指原始位置的距離
                float touchDeltaMag =
                    (touchZero.position - touchOne.position).magnitude;

                //算出距離相差多少
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                //範圍是1到1000，
                float v = scaleFactor * 100f;

                //負的差是放大，正的差是縮小
                v -= deltaMagnitudeDiff * speed;

                //限制放大縮小 從0.01至10
                scaleFactor = Mathf.Clamp(v, 1f, 1000f) / 100f;
            }
        }

        //如果可以調整大小，調整大小
        if (adjustScale)
        {
            transform.localScale = originalScale * scaleFactor;
        }
    }
}
//**********************************************
