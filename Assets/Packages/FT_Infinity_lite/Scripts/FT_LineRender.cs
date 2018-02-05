using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]

public class FT_LineRender : MonoBehaviour {

	public Transform lineSourcePoint;
	public Transform lineHitPoint;
	LineRenderer lr;

	void Start () {
		lr = GetComponent<LineRenderer>();	
	}
	
	void Update () {
		lr.SetPosition(1, new Vector3(
			lineHitPoint.position.x, lineHitPoint.position.y, lineHitPoint.position.z));
		lr.SetPosition(0, new Vector3(
			lineSourcePoint.position.x, lineSourcePoint.position.y, lineSourcePoint.position.z));		
	}
}
