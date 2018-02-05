using UnityEngine;

/// <summary>
/// Wrapper to pass input information as a single object.
/// </summary>
public class InputDataWrapper
{
	public float XThrow { get; set; }
	public float YThrow { get; set; }
	public bool RollButtonPressed { get; set; }
	public Ray MousePositionRay { get; set; }
}
