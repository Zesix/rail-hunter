using System.Collections;
using UnityEngine;
using Zenject;

public class MissileWeapon : MonoBehaviour, IWeapon
{
    // Dependencies
    private Pool _missileWeaponPool;
    private MissileExplosion.Pool _missileExplosionPool;
    
    // Configurable
    [SerializeField] private int _damage = 100;
    [SerializeField] private float _speed = 60f;
    [Range(0,1)] [SerializeField] private float _homingSensitivity = 0.8f;
    [SerializeField] private float _autoDespawnDelay = 4f;
    
    // Internal
    private Transform _target;
    private WaitForSeconds _despawnDelay;

    [Inject]
    public void Construct(Pool missileWeaponPool, MissileExplosion.Pool missileExplosionPool)
    {
        _missileWeaponPool = missileWeaponPool;
        _missileExplosionPool = missileExplosionPool;
    }

    private void Start()
    {
        _despawnDelay = new WaitForSeconds(_autoDespawnDelay);
    }
    
    public void FlyTowardTarget(Transform target)
    {
        _target = target;

        var targetDir = _target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDir);

        StartCoroutine(nameof(DespawnAfterDelay));
    }

    private void RotateTowardTargetPosition()
    {
        if (_target == null)
        {
            return;
        }
        var targetDirection = _target.position - transform.position;
        var rotationStep = _homingSensitivity * Time.deltaTime;

        var newDir = Vector3.RotateTowards(transform.forward, targetDirection, rotationStep, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);

        RotateTowardTargetPosition();
        DespawnSelfAfterMissingTarget();
    }

    private void DespawnSelfAfterMissingTarget()
    {
        if (_target == null)
        {
            return;
        }
        var targetDirection = (_target.position - transform.position).normalized;
        if (Vector3.Dot(targetDirection, transform.forward) <= 0f)
        {
            _missileWeaponPool.Despawn(this);
        }
    }

    private IEnumerator DespawnAfterDelay()
    {
        yield return _despawnDelay;
        _missileWeaponPool.Despawn(this);
    }
    
    private void OnParticleCollision(GameObject collidedObject)
    {
        if (collidedObject.GetComponent<ParticleSystem>())
        {
            StartCoroutine(nameof(SpawnExplosionAndDespawn));
        }
    }

    private IEnumerator SpawnExplosionAndDespawn()
    {
        var explosion = _missileExplosionPool.Spawn();
        explosion.transform.position = transform.position;
        yield return null;
        _missileWeaponPool.Despawn(this);
    }

    private void OnCollisionEnter(Collision collidedObject)
    {
        StartCoroutine(nameof(SpawnExplosionAndDespawn));
    }

    private void OnDrawGizmosSelected()
    {
        DrawRelativePositionRay();
    }

    private void DrawRelativePositionRay()
    {
        Gizmos.color = Color.red;
        var distance = Vector3.Distance(_target.position, transform.position);
        Gizmos.DrawRay(transform.position, transform.forward  * distance); 
    }

    public int GetImpactDamage()
    {
        return _damage;
    }
    
    public class Pool : MonoMemoryPool<MissileWeapon>
    {
        protected override void OnCreated(MissileWeapon missileWeapon)
        {
            base.OnCreated(missileWeapon);
        }
        protected override void Reinitialize(MissileWeapon missileWeapon)
        {
            missileWeapon.transform.position = Vector3.zero;
        }
        protected override void OnSpawned(MissileWeapon missileWeapon)
        {
            base.OnSpawned(missileWeapon);
        }
        protected override void OnDespawned(MissileWeapon missileWeapon)
        {
            base.OnDespawned(missileWeapon);
        }
    }
}
