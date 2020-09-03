﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float dampTime =0.1f;
	private Vector3 velocity= Vector3.zero;
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target)
		{
			Vector3 point= Camera.main.WorldToViewportPoint(target.position);
			Vector3 delta= target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f,point.y,point.z));
			Vector3 destination= transform.position +delta;
			transform.position =Vector3.SmoothDamp(transform.position,destination, ref velocity, dampTime);
		}
	}
}