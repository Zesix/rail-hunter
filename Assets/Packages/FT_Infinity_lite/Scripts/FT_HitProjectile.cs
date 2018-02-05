using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FT_HitProjectile : MonoBehaviour {

	private ParticleSystem projectile;
	public GameObject hitObject;
	public float speed = 10;

	List<ParticleCollisionEvent> collisionEv;

	void Start () {
		projectile = transform.GetComponent<ParticleSystem> ();
		var ma = projectile.main;
		ma.startSpeed = speed;
		collisionEv = new List<ParticleCollisionEvent>();

	}

	void OnParticleCollision(GameObject other){		
		ParticlePhysicsExtensions.GetCollisionEvents (projectile, other, collisionEv);

		for (int i = 0; i < collisionEv.Count; i++) {
			EmitAtLocation (collisionEv [i]);
		}
	}

	void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent){
		Vector3 pos = particleCollisionEvent.intersection;
		Quaternion rot = Quaternion.LookRotation (particleCollisionEvent.normal);
		Instantiate(hitObject, pos, rot);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
