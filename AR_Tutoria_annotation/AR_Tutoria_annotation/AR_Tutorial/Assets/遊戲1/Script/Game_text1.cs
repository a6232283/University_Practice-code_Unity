using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Game_text1 : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Main.Instance.Web.Game1("怪物生成", SystemInfo.deviceModel));
    }

    public IEnumerator Game1(string date, string id_name)
    {
        WWWForm form = new WWWForm();
        form.AddField("id2", date);
        form.AddField("id_name", id_name);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/game1.php/", form))
        {
           
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    
}
