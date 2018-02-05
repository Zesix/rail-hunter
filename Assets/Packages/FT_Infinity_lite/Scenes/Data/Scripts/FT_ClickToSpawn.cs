using UnityEngine;
using System.Collections;

public class FT_ClickToSpawn : MonoBehaviour {

	public GameObject prefab;


	void Start () {
	
	}
	

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Instantiate(prefab, new Vector3(0,0,0), prefab.transform.rotation);
		}
	}
}
