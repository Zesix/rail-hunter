using UnityEngine;
using Zenject;

public class ShipExplosion : MonoBehaviour
{
    // Dependencies
    private Pool _shipExplosionPool;
    
    // Internal
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;

    [Inject]
    public void Construct(Pool shipExplosionPool)
    {
        _shipExplosionPool = shipExplosionPool;
    }

    private void OnEnable()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            _audioSource.volume = PlayerPrefs.GetFloat("SoundVolume");
        }
        _audioSource.Play();
    }
    
    private void Update()
    {
        if (!_particleSystem.isPlaying)
        {
            _shipExplosionPool.Despawn(this);
        }
    }
    
    public class Pool : MonoMemoryPool<ShipExplosion>
    {
        protected override void OnCreated(ShipExplosion shipExplosion)
        {
            base.OnCreated(shipExplosion);
        }
        protected override void Reinitialize(ShipExplosion shipExplosion)
        {
            shipExplosion.GetComponent<ParticleSystem>().Clear();
        }
        protected override void OnSpawned(ShipExplosion shipExplosion)
        {
            base.OnSpawned(shipExplosion);
        }
        protected override void OnDespawned(ShipExplosion shipExplosion)
        {
            base.OnDespawned(shipExplosion);
        }
    }
}
