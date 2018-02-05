using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour {

	public GameObject[] effects;
	public Text text;
	public Camera mainCam;
	public Transform spawn;
	public Transform parentObj;

	//public GameObject ps;
	int time = 0;
	public int count = 200;
	int fxNum = 0;
	bool isBeam = false;

	// Use this for initialization
	void Start () {
		fxNum = 0;
		text.text = effects [fxNum].name;		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
		Plane ground = new Plane (Vector3.up, Vector3.zero);
		float rayDistance;
		if (ground.Raycast (ray, out rayDistance)) {
			Vector3 point = ray.GetPoint (rayDistance);
			Vector3 correctPoint = new Vector3 (point.x, transform.position.y, point.z);
			transform.LookAt (correctPoint);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (fxNum >= effects.Length -1) {
				fxNum = 0;
			} else {
				fxNum++;
			}
			text.text = effects [fxNum].name;
			for (int i = 0; i < parentObj.childCount; ++i) {
				GameObject.Destroy (parentObj.GetChild (i).gameObject);
			}
			time = 0;
			isBeam = false;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (fxNum <= 0) {
				fxNum = effects.Length -1;
			} else {
				fxNum--;
			}
			text.text = effects [fxNum].name;
			for (int i = 0; i < parentObj.childCount; ++i) {
				GameObject.Destroy (parentObj.GetChild (i).gameObject);
			}
			time = 0;
			isBeam = false;
		}		
		time++;
		if(time > count){
			float x = Random.Range (-2.5f, 2.5f);
			float z = Random.Range (-2.5f, 2.5f);

			if (fxNum < 4) {
				GameObject psPrefab = Instantiate (effects [fxNum]) as GameObject;
				psPrefab.transform.position = new Vector3 (x, 1.0f, z);
				psPrefab.transform.parent = parentObj;

			}

			if (fxNum == 4) {
				GameObject projectile = Instantiate (effects[4], spawn.position, spawn.rotation);	
				projectile.transform.parent = parentObj;

			}

			if (fxNum > 4 && isBeam == false) {
				isBeam = true;
				GameObject projectile = Instantiate (effects[fxNum], spawn.position, spawn.rotation);	
				projectile.transform.parent = parentObj;
			}
			time = 0;

		}

		
		
	}
}
