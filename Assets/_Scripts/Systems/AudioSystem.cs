using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Insanely basic audio system which supports 3D sound.
/// Ensure you change the 'Sounds' audio source to use 3D spatial blend if you intend to use 3D sounds.
/// </summary>
public class AudioSystem : StaticInstance<AudioSystem>
{
  [SerializeField] private AudioSource _musicSource;
  [SerializeField] private AudioSource _soundsSource;
  [Range(0.0f, 1.0f)] [SerializeField] private float _volume = 1.0f;
  [SerializeField] private bool _isSoundsEnabled = true;
  public bool IsSoundsEnabled
  {
    get => _isSoundsEnabled;
    set
    {
      _isSoundsEnabled = value;
      _musicSource.mute = !value;
      _soundsSource.mute = !value;
    }
  }

  public float Volume
  {
    get => _volume;
    set
    {
      _volume = Mathf.Clamp01(value);
      _musicSource.volume = Volume;
      _soundsSource.volume = Volume;
    }
  }

  public void PlayMusic(AudioClip clip)
  {
    _musicSource.clip = clip;
    _musicSource.volume = Volume;
    _musicSource.Play();
  }

  public void PlaySound(AudioClip clip, Vector3 pos)
  {
    _soundsSource.transform.position = pos;
    PlaySound(clip);
  }

  public void PlaySound(AudioClip clip)
  {
    _soundsSource.PlayOneShot(clip, Volume);
  }
}