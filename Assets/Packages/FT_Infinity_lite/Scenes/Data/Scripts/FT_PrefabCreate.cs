using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class FT_PrefabCreate : MonoBehaviour {

	private Transform prefabList;
	private int prefabNum = 0;
	private int prefabMaxCount = 0;
	public int randomSpawnMaxCount = 10;
	private int randomSpawnCount = 0;
	public bool randomSpawnSwitch = false;
	public float spawnTime = 2.0f;
	private float timeElapsed;
	private Transform spawnPrefab;

	public FT_PrefabText text;

	void Start () {

		List<Transform> objList = new List<Transform>();

		prefabMaxCount = transform.childCount;
		for ( int i = 0 ; i < prefabMaxCount ; i++ ) {
			objList.Add(transform.GetChild(i));
		}

		objList.Sort((obj1, obj2) => string.Compare(obj1.name, obj2.name));

		foreach ( var obj in objList ) {
			obj.SetSiblingIndex(prefabMaxCount - 1);
		}

		prefabList = transform.GetChild (prefabNum);

		if (randomSpawnSwitch == false) {
			spawnPrefab = Instantiate (prefabList, new Vector3 (0, 0, 0), Quaternion.identity) as Transform;
			spawnPrefab.gameObject.SetActive (true);
		}

		randomSpawnCount = 0;

		text.prefabName = prefabList.name;
	}

	void Update()
	{
		if (randomSpawnSwitch == true) {
			timeElapsed += Time.deltaTime;

			if (timeElapsed >= spawnTime) {
				float x = UnityEngine.Random.Range(-1.5f, 1.5f);
				float z = UnityEngine.Random.Range(-1.5f, 1.5f);

				randomSpawnCount++;

				if (randomSpawnCount < randomSpawnMaxCount) {
					spawnPrefab = Instantiate (prefabList, new Vector3 (x, 0, z), Quaternion.identity) as Transform;
					spawnPrefab.gameObject.SetActive (true);
				} 
				timeElapsed = 0.0f;
			}
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			prefabList.gameObject.SetActive(false);
			prefabNum ++;
			if (prefabNum >= prefabMaxCount) {
				prefabNum = 0;
			}
			prefabList = transform.GetChild (prefabNum);

			if (randomSpawnSwitch == false) {
				spawnPrefab = Instantiate (prefabList, new Vector3 (0, 0, 0), Quaternion.identity) as Transform;
				spawnPrefab.gameObject.SetActive (true);
			}

			randomSpawnCount = 0;
			text.prefabName = prefabList.name;
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			prefabList.gameObject.SetActive(false);
			prefabNum --;
			if (prefabNum < 0) {
				prefabNum = prefabMaxCount - 1;
			}
			prefabList = transform.GetChild (prefabNum);

			if (randomSpawnSwitch == false) {
				spawnPrefab = Instantiate (prefabList, new Vector3 (0, 0, 0), Quaternion.identity) as Transform;
				spawnPrefab.gameObject.SetActive (true);
			}

			randomSpawnCount = 0;
			text.prefabName = prefabList.name;
		}
	}
}
