using UnityEngine;

public sealed class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        Instance = this;
    }

    public void Play(AudioClip clip)
    {
        effectsSource.pitch = 1f;
        effectsSource.PlayOneShot(clip);
    }

    public void PlayVariablePitch(AudioClip clip)
    {
        effectsSource.pitch = Random.Range(0.9f, 1.1f);
        effectsSource.PlayOneShot(clip);
    }

    public void SetSFXVolume(float volume)
    {
        effectsSource.volume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
