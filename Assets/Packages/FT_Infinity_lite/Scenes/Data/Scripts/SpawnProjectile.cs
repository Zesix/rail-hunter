using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnProjectile : MonoBehaviour {

	public Camera mainCam;
	public Transform spawn;
	public GameObject[] effects;
	private int count = 0;
	public Text text;

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
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (count <= 0) {
				count = effects.Length -1;
			} else {
				count--;
			}
			text.text = effects [count].name;
		}		

		//Shoot
		if(Input.GetMouseButtonDown(0)){
			GameObject projectile = Instantiate (effects[count], spawn.position, spawn.rotation);
		}
	}
}
