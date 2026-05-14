using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Combat Sounds")]
    public AudioClip punchClip;
    public AudioClip kickClip;
    public AudioClip hitClip;
    public AudioClip koClip;

    [Header("UI")]
    public Slider volumeSlider;
    public Toggle muteToggle;

    void Start()
    {
        volumeSlider.value = musicSource.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
        muteToggle.onValueChanged.AddListener(SetMute);
    }

    public void PlayPunch() => sfxSource.PlayOneShot(punchClip);
    public void PlayKick()  => sfxSource.PlayOneShot(kickClip);
    public void PlayHit()   => sfxSource.PlayOneShot(hitClip);
    public void PlayKO()    => sfxSource.PlayOneShot(koClip);

    void SetVolume(float value)
    {
        musicSource.volume = value;
        sfxSource.volume = value;
    }

    void SetMute(bool muted)
    {
        musicSource.mute = muted;
        sfxSource.mute = muted;
    }
}
