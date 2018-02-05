using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class MissileExplosion : MonoBehaviour
{
	// Dependencies
	private Pool _missileExplosionPool;
	
	// Internal
	private ParticleSystem _particleSystem;
	private AudioSource _audioSource;

	[Inject]
	public void Construct(Pool missileExplosionPool)
	{
		_missileExplosionPool = missileExplosionPool;
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
			_missileExplosionPool.Despawn(this);
		}
	}
    
	public class Pool : MonoMemoryPool<MissileExplosion>
	{
		protected override void OnCreated(MissileExplosion missileExplosion)
		{
			base.OnCreated(missileExplosion);
		}
		protected override void Reinitialize(MissileExplosion missileExplosion)
		{
			missileExplosion.GetComponent<ParticleSystem>().Clear();
		}
		protected override void OnSpawned(MissileExplosion missileExplosion)
		{
			base.OnSpawned(missileExplosion);
		}
		protected override void OnDespawned(MissileExplosion missileExplosion)
		{
			base.OnDespawned(missileExplosion);
		}
	}
}
