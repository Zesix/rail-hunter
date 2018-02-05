using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CloudView : MonoBehaviour 
{
	[Tooltip("X Movement in m^-1/sec")] [SerializeField]
	private float _xMoveSpeed = 0.1f;

	[Tooltip("Distance to move the object after colliding with the boundary.")] [SerializeField]
	private float _xPositionResetDistance = 1600f;

	private void Update () 
	{
		// Move along X axis
		transform.position = new Vector3(transform.position.x + _xMoveSpeed, transform.position.y, transform.position.z);
	}

	private void OnTriggerEnter (Collider col)
	{
		if (col.GetComponent<CloudMovementBoundary>())
		{
			transform.position = new Vector3(transform.position.x - _xPositionResetDistance, transform.position.y, transform.position.z);
		}
	}
}
