using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OnBag : MonoBehaviour
{
    public GameObject myBag;
    bool isOpen=false;
    private void Update()
    {
        
    }
    public void OpenBag()
    {
        if (!isOpen)
        {
            myBag.SetActive(true);
            isOpen = !isOpen;
        }
        else
        {
            myBag.SetActive(false);
            isOpen = !isOpen;
        }
    }
}
