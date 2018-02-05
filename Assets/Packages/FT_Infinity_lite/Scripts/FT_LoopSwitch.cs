using UnityEngine;
using System.Collections;

public class FT_LoopSwitch : MonoBehaviour {

	public float loopOffTiming = 0;

	private ParticleSystem[] particleSystems;

	private float currentTime = 0;



	void Start () {
		particleSystems = GetComponentsInChildren<ParticleSystem>();
	}
	

	void Update () {
		if (loopOffTiming != 0) {
			currentTime += Time.deltaTime;
		
			if (currentTime > loopOffTiming) {
				foreach (ParticleSystem particles in particleSystems)
					particles.loop = false;
			}
		}
			
	}
}
