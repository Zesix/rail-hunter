using System.Collections;
using UnityEngine;
using Zenject;

public abstract class PlayableShip : MonoBehaviour
{
    // Dependencies
    protected PlayerHitSignal _playerHitSignal;
    
    // Configurable
    [SerializeField]
    protected float ScreenMovementSpeed;
    [SerializeField]
    protected float XClamp;
    [SerializeField]
    protected float YClamp;
    [SerializeField]
    protected float PositionPitchFactor;
    [SerializeField]
    protected float ControlPitchFactor;
    [SerializeField]
    protected float PositionYawFactor;
    [SerializeField]
    protected float ControlRollFactor;
    [SerializeField]
    protected float RotateTowardCursorTime;
    [SerializeField]
    protected float AileronRollTime;
    [SerializeField]
    protected Transform ExplosionPrefab;

    [Inject]
    public virtual void Construct(PlayerHitSignal playerHitSignal)
    {
        _playerHitSignal = playerHitSignal;
    }

    public virtual void TranslateShip(float xThrow, float yThrow) {}

    public virtual void RotateShip(float xThrow, float yThrow) {}

    public virtual void LookAtPositionFromRay(Ray positionRay) {}

    public virtual void AileronRoll(float xThrow) {}

    private void OnTriggerEnter(Collider collidedObject)
    {
        var collidedWeapon = collidedObject.GetComponent<IWeapon>();
        if (collidedWeapon != null)
        {
            _playerHitSignal.Fire(collidedWeapon.GetImpactDamage());
        }
    }

    public virtual IEnumerator DespawnShip()
    {
        yield return null;
    }
}
