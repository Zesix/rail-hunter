using UnityEngine;
using System.Collections;

public class FT_LineHitPoint : MonoBehaviour {

	public bool freezeHeightPosition = true;
	public float heightValue = 1.5f;
	public Transform target;

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 500f)) {
			if (freezeHeightPosition == false) {
				transform.position = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
				transform.LookAt (target.transform);
			} else {
				transform.position = new Vector3 (hit.point.x, heightValue, hit.point.z);
				transform.LookAt (target.transform);
			}
		}	
	}
}
