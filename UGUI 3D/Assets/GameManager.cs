using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public void OnStarGame(string ScneneName)
    {
        Application.LoadLevel(ScneneName);
    }
}
