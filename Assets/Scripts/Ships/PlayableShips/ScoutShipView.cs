using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

public class ScoutShipView : PlayableShip
{
    // Dependencies
    private ShipExplosion.Pool _shipExplosionPool;
    private GameStateChangedSignal _gameStateChangedSignal;
    
    // Internal
    private bool _isRolling;
    private Vector3 _startGamePosition;

    [Inject]
    public void Construct(GameStateChangedSignal gameStateChangedSignal, ShipExplosion.Pool shipExplosionPool)
    {
        _gameStateChangedSignal = gameStateChangedSignal;
        _shipExplosionPool = shipExplosionPool;
    }

    private void Start()
    {
        _gameStateChangedSignal += OnGameStateChanged;
        _startGamePosition = transform.localPosition;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _gameStateChangedSignal -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameStateBase gameState)
    {
        if (gameState is PlayState)
        {
            gameObject.SetActive(true);
            transform.localPosition = _startGamePosition;
        }
    }
    
    public override void TranslateShip(float xThrow, float yThrow)
    {
        var xOffset = xThrow * ScreenMovementSpeed * Time.deltaTime;
        if (_isRolling)
        {
            xOffset *= 1.8f;
        }
        var rawNewXPos = transform.localPosition.x + xOffset;
        var clampedNewXPos = Mathf.Clamp(rawNewXPos, -XClamp, XClamp);
        
        var yOffset = yThrow * ScreenMovementSpeed * Time.deltaTime;
        var rawNewYPos = transform.localPosition.y + yOffset;
        var clampedNewYPos = Mathf.Clamp(rawNewYPos, -YClamp, YClamp);
        
        transform.localPosition = new Vector3(clampedNewXPos, clampedNewYPos, transform.localPosition.z);
    }

    public override void RotateShip(float xThrow, float yThrow)
    {
        // Hardcoded magic number 1.5f because I don't want too many rotation configs in PlayerShipData.
        var pitchDueToPosition = transform.localPosition.y / 1.5f * PositionPitchFactor;
        var pitchDueToControlThrow = yThrow * ControlPitchFactor;
        var pitch = pitchDueToPosition + pitchDueToControlThrow;

        var yaw = transform.localPosition.x / 1.5f * PositionYawFactor;

        var roll = xThrow * ControlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    public override void LookAtPositionFromRay(Ray mousePositionRay)
    {
        if (_isRolling)
        {
            return;
        }
        var targetDirection = mousePositionRay.GetPoint(Camera.main.farClipPlane * 2f);
        transform.DOLookAt(targetDirection, RotateTowardCursorTime);
    }

    public override void AileronRoll(float xThrow)
    {
        var horizontalDirectionModifier = xThrow < 0 ? 1 : -1;
        if (xThrow == 0) { horizontalDirectionModifier = 0; }
        
        if (_isRolling || horizontalDirectionModifier == 0)
        {
            return;
        }
        _isRolling = true;

        var rotationSequence = AileronHorizontalRollRotation(horizontalDirectionModifier);
        rotationSequence.Play().OnComplete(() => { _isRolling = false; });
    }

    private Sequence AileronHorizontalRollRotation(float horizontalDirectionModifier)
    {
        var endRotation = new Vector3(
            transform.localRotation.eulerAngles.x, 
            transform.localRotation.eulerAngles.y, 
            transform.localRotation.eulerAngles.z + 360 * horizontalDirectionModifier);
        var rollRotation = transform.DOLocalRotate(endRotation, AileronRollTime, RotateMode.FastBeyond360);
        return DOTween.Sequence().Append(rollRotation);
    }

    public override IEnumerator DespawnShip()
    {
        var explosionPrefab = _shipExplosionPool.Spawn();
        explosionPrefab.transform.SetParent(transform.parent);
        explosionPrefab.transform.localScale = transform.localScale;
        explosionPrefab.transform.position = transform.position;
        
        yield return null;
        
        gameObject.SetActive(false);
    }
}
