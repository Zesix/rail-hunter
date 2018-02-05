using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FT_LineSourcePoint : MonoBehaviour {

	public Transform target;

	void Update () {		
		transform.LookAt (target.transform);
	}
}
