using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarge : MonoBehaviour {

    public Transform target;
    public float FollowTime;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        iTween.MoveUpdate(this.gameObject, iTween.Hash("position", target.position+offset, "time", FollowTime, "easetype", iTween.EaseType.easeInOutSine));
	}
}
