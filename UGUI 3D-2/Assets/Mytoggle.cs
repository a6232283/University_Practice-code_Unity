using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mytoggle : MonoBehaviour
{ 
    public GameObject isOngameObject;
    public GameObject isOffgameObject;
    private Toggle toggle;
  

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        OnValueChange(toggle.isOn);
    }

    public void OnValueChange(bool isOn)
    {
        isOngameObject.SetActive(isOn);
        isOffgameObject.SetActive(!isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
