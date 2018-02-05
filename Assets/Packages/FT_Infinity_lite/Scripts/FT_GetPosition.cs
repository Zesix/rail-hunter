using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FT_GetPosition : MonoBehaviour {

	public Transform refPositionObj;
	public Vector3 offset;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pos = refPositionObj.position + offset;
		this.transform.position = pos;		
	}
}
