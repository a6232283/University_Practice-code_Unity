using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager2 : SceneManager
{
    public void OnStarGame(string ScneneName)
    {
        SceneManager.LoadScene(ScneneName);
    }
}
