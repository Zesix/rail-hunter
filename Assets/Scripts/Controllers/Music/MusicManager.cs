using UnityEngine;
using System.Collections;
using Zenject;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    // Configurable
    [SerializeField] private MusicPlaylist _menuPlaylist;
    [SerializeField] private MusicPlaylist _gameplayPlaylist;
    
    // Dependencies
    private GameStateChangedSignal _gameStateChangedSignal;

    [Inject]
    private void Construct(GameStateChangedSignal gameStateChangedSignal)
    {
        _gameStateChangedSignal = gameStateChangedSignal;
    }
    
    [Range(0,1)] [SerializeField]
    private float _volume = 0.5f;
    public float Volume
    {
        set
        {
            _volume = value;
            _audioSource.volume = value;
        }
    }

    private MusicPlaylist _playlist;
    public bool Shuffle;
    public RepeatMode Repeat;
    public float FadeDuration;
    public bool PlayOnAwake;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        
        ChangePlaylist(_menuPlaylist);
        if (FadeDuration > 0)
            _audioSource.volume = 0f;
        else
            Volume = _volume;
        if (_playlist == null)
            return;
        if (_playlist.MusicList.Length > 0)
            _audioSource.clip = _playlist.MusicList[0];
        else
            Debug.LogError("There is no music in the list");
        
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (PlayOnAwake)
        {
            Play();
        }
    }

    private void Start()
    {
        _gameStateChangedSignal += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        _gameStateChangedSignal -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameStateBase gameState)
    {
        if (gameState is MenuState)
        {
            ChangePlaylist(_menuPlaylist);
        }
        if (gameState is PlayState)
        {
            ChangePlaylist(_gameplayPlaylist);
        }
    }

    public void Play()
    {
        if (_playlist)
        {
            StartCoroutine(PlayMusicList());
        }
    }

    public void Stop(bool fade)
    {
        StopAllCoroutines();
        if (fade)
            StartCoroutine(StopWithFade());
        else
            _audioSource.Stop();
    }

    public void ChangePlaylist(MusicPlaylist list)
    {
        _playlist = list;
        _counter = 0;
        StopAllCoroutines();
        StartCoroutine(ChangePlaylistE());
    }

    private IEnumerator ChangePlaylistE()
    {
        if (_audioSource.isPlaying)
            yield return StartCoroutine(StopWithFade());
        StartCoroutine(PlayMusicList());
    }

    private IEnumerator StopWithFade()
    {
        if (FadeDuration > 0)
        {
            var lerpValue = 0f;
            while (lerpValue < 1f)
            {
                lerpValue += Time.deltaTime / FadeDuration;
                _audioSource.volume = Mathf.Lerp(_volume, 0f, lerpValue);
                yield return null;
            }
        }
        _audioSource.Stop();
    }

    public void PlaySong(AudioClip song)
    {
        StartCoroutine(PlaySongE(song));
    }

    private IEnumerator PlaySongE(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
        StartCoroutine(FadeIn());
        while (_audioSource.isPlaying)
        {
            if (_audioSource.clip.length - _audioSource.time <= FadeDuration)
            {
                yield return StartCoroutine(FadeOut());
            }
            yield return null;
        }
    }

    private int _counter;

    private IEnumerator PlayMusicList()
    {
        while (true)
        {
            yield return StartCoroutine(PlaySongE(_playlist.MusicList[_counter]));
            if (Repeat == RepeatMode.Track)
            {

            }
            else if (Shuffle)
            {
                var newTrack = GetNewTrack();
                while (newTrack == _counter && _playlist.MusicList.Length != 1)
                {
                    newTrack = GetNewTrack();
                }
                _counter = newTrack;

            }
            else
            {
                _counter++;
                if (_counter > _playlist.MusicList.Length - 1)
                {
                    if (Repeat == RepeatMode.Playlist)
                    {
                        _counter = 0;
                    }
                    else
                        yield break;
                }
            }
        }
    }

    private IEnumerator FadeOut()
    {
        if (FadeDuration > 0f)
        {
            var startTime = _audioSource.clip.length - FadeDuration;
            var lerpValue = 0f;
            while (lerpValue < 1f && _audioSource.isPlaying)
            {
                lerpValue = Mathf.InverseLerp(startTime, _audioSource.clip.length, _audioSource.time);
                _audioSource.volume = Mathf.Lerp(_volume, 0f, lerpValue);
                yield return null;
            }
            _audioSource.volume = 0f;
        }
    }

    private IEnumerator FadeIn()
    {
        if (FadeDuration > 0f)
        {
            var lerpValue = 0f;
            while (lerpValue < 1f && _audioSource.isPlaying)
            {
                lerpValue = Mathf.InverseLerp(0f, FadeDuration, _audioSource.time);
                _audioSource.volume = Mathf.Lerp(0f, _volume, lerpValue);
                yield return null;
            }
            _audioSource.volume = _volume;
        }
    }

    private int GetNewTrack()
    {
        return Random.Range(0, _playlist.MusicList.Length);
    }

    public void SetMusicVolume(float amount)
    {
        _audioSource.volume = amount;
        PlayerPrefs.SetFloat("MusicVolume", amount);
        PlayerPrefs.Save();
    }
}

public enum RepeatMode
{
    Playlist,
    Track
}
