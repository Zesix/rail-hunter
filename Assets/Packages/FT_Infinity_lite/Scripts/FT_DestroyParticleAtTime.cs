using UnityEngine;
using System.Collections;

public class FT_DestroyParticleAtTime : MonoBehaviour {

	public float destroyTime = 10.0f;

	void Start () {
		Destroy(gameObject, destroyTime);	
	}
	

	void Update () {
	
	}
}
