using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

#if UNITY_EDITOR
using input = GoogleARCore.InstantPreviewInput;
#endif

public class ARController : MonoBehaviour
{
    //我們將找到此列表以及當前幀中檢測到的弧面
    private List<DetectedPlane> m_NewTrackedPlanes = new List<DetectedPlane>();
    //球體
    public GameObject GridPrefab;
    //門
    public GameObject Portal;
    //ARcore 攝像頭
    public GameObject ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //檢查arocre狀態
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        //以下函數將使用檢測到的弧面填充m_NewTrackedPlanes
        Session.GetTrackables<DetectedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

        //在m_NewTrackedPlanes中為每個軌道平面實例化網格
        for (int i = 0; i < m_NewTrackedPlanes.Count; i++)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);
            //此功能將設置網格的位置並修改附加網格的頂點
            grid.GetComponent<GridVisuallser>().Initialize(m_NewTrackedPlanes[i]);
        }
        //觸摸屏幕
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        //現在讓我們檢查用戶是否觸摸了任何被跟踪的地板
        TrackableHit hit;
        if(Frame.Raycast(touch.position.x,touch.position.y,TrackableHitFlags.PlaneWithinPolygon,out hit))
        {
            //現在讓我們將傳送門平鋪在我們接觸的跟踪平面的頂部
            Portal.SetActive(true);

            //創建一個新的錨點
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            //將門的位置設置為與命中位置相同
            Portal.transform.position = hit.Pose.position;
            Portal.transform.rotation = hit.Pose.rotation;

            //我們希望門戶網站面對攝像頭
            Vector3 cameraPosition = ARCamera.transform.position;

            //門戶只能繞y軸旋轉
            cameraPosition.y = hit.Pose.position.y;

            //旋轉門以面對攝像頭
            Portal.transform.LookAt(cameraPosition, Portal.transform.up);

            // arcore將繼續了解世界並相應更新錨點，因此我們需要將門戶網站附加到錨點上
            Portal.transform.parent = anchor.transform;
        }
    }
}
