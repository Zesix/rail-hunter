using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShipData : ScriptableObject
{
    [Header("General")] 
    
    [SerializeField] private int _minimumHitsBeforeDeath = 1;
    [SerializeField] private int _maximumHitsBeforeDeath = 6;
    [SerializeField] private int _scoreMultiplier = 10;
    [SerializeField] private float _fireRateMin = 1f;
    [SerializeField] private float _fireRateMax = 2.5f;
    
    public int MaxHits
    {
        get
        {
            if (_minimumHitsBeforeDeath > _maximumHitsBeforeDeath)
            {
                Debug.LogError("Max hits before death is less than minimum hits before death.");
            }
            return Random.Range(_minimumHitsBeforeDeath, _maximumHitsBeforeDeath + 1);
        }
    }    
    public float WeaponFireRate
    {
        get
        {
            if (_fireRateMin > _fireRateMax)
            {
                Debug.LogError("Maximum fire rate is less than minimum fire rate.");
            }
            return Random.Range(_fireRateMin, _fireRateMax + 1);
        }   
    }

    public int ScoreMultiplier => _scoreMultiplier;
}
