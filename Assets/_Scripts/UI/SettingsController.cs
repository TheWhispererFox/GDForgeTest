using UnityEngine;

public class SettingsController : MonoBehaviour
{
  [SerializeField] private Animator _settingsPanelAnimator;
  public void ChangeSoundVolume(float volume)
  {
    AudioSystem.Instance.Volume = volume;
  }

  public void ToggleSound(bool isChecked)
  {
    AudioSystem.Instance.IsSoundsEnabled = isChecked;
  }

  public void OpenWeb(string url)
  {
    Application.OpenURL(url);
  }

  public void Close()
  {
    _settingsPanelAnimator.SetTrigger("Close");
  }
}
