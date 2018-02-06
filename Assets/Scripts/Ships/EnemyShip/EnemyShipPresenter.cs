using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider))]
public class EnemyShipPresenter : MonoBehaviour
{
    // Dependencies
    private EnemyShipModel _model;
    private ScoreSignal _scoreSignal;
    private ShipExplosion.Pool _shipExplosionPool;
    private MissileWeapon.Pool _missileWeaponPool;
    private PlayableShip _playerShip;

    // Configurable
    [SerializeField] private Color _emissionOnHitColor;
    [SerializeField] private float _emissionFlashDuration = 0.1f;
    [SerializeField] private float _rangeToEngageTarget = 80f;
    [SerializeField] private Transform _gunMount;
    
    // Internal
    private WaitForSeconds _emissionOnHitDelay;
    private Renderer[] _childRenderers;
    
    [Inject]
    public void Construct(EnemyShipModel model, 
        ScoreSignal scoreSignal,
        ShipExplosion.Pool shipExplosionPool,
        MissileWeapon.Pool missileWeaponPool,
        PlayableShip playerShip)
    {
        _model = model;
        _scoreSignal = scoreSignal;
        _shipExplosionPool = shipExplosionPool;
        _missileWeaponPool = missileWeaponPool;
        _playerShip = playerShip;
    }

    private void Start()
    {
        _emissionOnHitDelay = new WaitForSeconds(_emissionFlashDuration);
        _childRenderers = GetComponentsInChildren<Renderer>();

        InvokeRepeating(nameof(FireWeaponAtTargetWhenInRange), _model.WeaponFireRate, _model.WeaponFireRate);
    }
    
    private void OnParticleCollision(GameObject collidedObject)
    {
        _model.IncrementHits(1);
        
        StopCoroutine(nameof(FlashEmissionCoroutine));
        StartCoroutine(nameof(FlashEmissionCoroutine));

        if (_model.CurrentHits >= _model.MaxHits)
        {
            StartCoroutine(nameof(DespawnShip));
        }
    }
    
    private IEnumerator FlashEmissionCoroutine()
    {
        SetEmissionForChildObjects(_emissionOnHitColor);
        yield return _emissionOnHitDelay;
        SetEmissionForChildObjects(Color.black);
    }

    // WARNING: This overrides emission color for all child materials.
    // If this is not intended, use a different method for flashing a color on hit!
    private void SetEmissionForChildObjects(Color color)
    {
        foreach (var rend in _childRenderers)
        {
            foreach (var mat in rend.materials)
            {
                mat.SetColor("_EmissionColor", color);
            }
        }
    }

    private void FireWeaponAtTargetWhenInRange()
    {
        if (Vector3.Distance(_playerShip.transform.position, transform.position) >= _rangeToEngageTarget ||
            gameObject.activeInHierarchy == false || transform.parent.gameObject.activeInHierarchy == false)
        {
            return;
        }
        var weapon = _missileWeaponPool.Spawn().GetComponent<MissileWeapon>();
        weapon.transform.position = _gunMount.transform.position;
        weapon.FlyTowardTarget(_playerShip.transform);
    }

    private IEnumerator DespawnShip()
    {
        _scoreSignal.Fire(_model.ScoreAmount, this);
        
        var explosionPrefab = _shipExplosionPool.Spawn();
        // Reduce scale of explosion prefab so it's not so large.
        explosionPrefab.transform.localScale = transform.localScale * 0.9f;
        explosionPrefab.transform.position = transform.position;

        yield return null;
        SetEmissionForChildObjects(Color.black);
        gameObject.SetActive(false);
    }

    public void ResetShip()
    {
        _model.ClearHits();
    }
}
