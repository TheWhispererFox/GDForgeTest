using UnityEngine;

public class MainMenuController : MonoBehaviour
{
  [SerializeField] Animator _shopPanelAnimator;
  [SerializeField] Animator _settingsPanelAnimator;
  public void ExitBtn_Click()
  {
    Application.Quit();
  }

  public void ShopBtn_Click()
  {
    _shopPanelAnimator.SetTrigger("Open");
  }

  public void SettingsBtn_Click()
  {
    _settingsPanelAnimator.SetTrigger("Open");
  }
}
