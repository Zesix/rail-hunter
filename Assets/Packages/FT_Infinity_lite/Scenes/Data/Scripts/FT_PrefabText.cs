using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FT_PrefabText : MonoBehaviour {

	public string prefabName ;

	void Start () {

	}

	void Update () {
		this.GetComponent<Text>().text = "Prefab Name : " + prefabName;
	}
}