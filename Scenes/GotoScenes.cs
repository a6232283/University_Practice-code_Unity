using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScenes : MonoBehaviour
{

    public Scene scene;

    public void onclick()
    {
        SceneManager.LoadScene(scene.ToString());
    }
   
}
