using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBeam : MonoBehaviour {

	public Camera mainCam;
	public Transform spawn;
	public GameObject[] effects;
	public Transform parentObj;
	private int count = 0;
	public Text text;
	bool isBeam = false;

	// Use this for initialization
	void Start () {
		text.text = effects [count].name;
	}
	
	// Update is called once per frame
	void Update () {
		//Player Look at Mouse Position
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
		Plane ground = new Plane (Vector3.up, Vector3.zero);
		float rayDistance;
		if (ground.Raycast (ray, out rayDistance)) {
			Vector3 point = ray.GetPoint (rayDistance);
			Vector3 correctPoint = new Vector3 (point.x, transform.position.y, point.z);
			transform.LookAt (correctPoint);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (count >= effects.Length -1) {
				count = 0;
			} else {
				count++;
			}
			text.text = effects [count].name;
			for (int i = 0; i < parentObj.childCount; ++i) {
				GameObject.Destroy (parentObj.GetChild (i).gameObject);
			}
			isBeam = false;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (count <= 0) {
				count = effects.Length -1;
			} else {
				count--;
			}
			text.text = effects [count].name;
			for (int i = 0; i < parentObj.childCount; ++i) {
				GameObject.Destroy (parentObj.GetChild (i).gameObject);
			}
			isBeam = false;
		}		

		//Shoot
		if(isBeam == false){
			isBeam = true;
			GameObject beam = Instantiate (effects[count], spawn.position, spawn.rotation);
			beam.transform.parent = parentObj;
		}
	}
}
