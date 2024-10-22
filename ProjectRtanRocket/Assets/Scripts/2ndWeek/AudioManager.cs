using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip audipClip;
    private bool isAudioSourceAdded = false;

    protected override void Awake()
    {
        base.Awake();

        audioSource = gameObject.AddComponent<AudioSource>();
        isAudioSourceAdded = true;
    }

    public void PlayBGM()
    {
        audioSource.Play();
    }

    public void PlayBGM(AudioClip _audioClip)
    {
        audioSource.clip = _audioClip;
        audioSource.Play();
    }

    public void PlayBGM(AudioClip _audioClip, float _volume)
    {
        audioSource.clip = _audioClip;
        audioSource.volume = _volume;
        audioSource.Play();
    }

    public void PlayBGM(AudioClip _audioClip, bool _isLoop)
    {
        audioSource.clip = _audioClip;
        audioSource.loop = _isLoop;
        audioSource.Play();
    }

    public void PlayBGM(AudioClip _audioClip, float _volume, bool _isLoop)
    {
        audioSource.clip = _audioClip;
        audioSource.volume = _volume;
        audioSource.loop = _isLoop;
        audioSource.Play();
    }

    public void SetVolume(float _volume)
    {
        audioSource.volume = _volume;
    }

    public void SetLoop(bool _isLoop)
    {
        audioSource.loop = _isLoop;
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public bool CheckPlayingMusic()
    {
        return audioSource.isPlaying;
    }
}