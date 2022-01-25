using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingBarController : MonoBehaviour
{
  [SerializeField] private Slider _loadingSlider;
  [SerializeField] private TMP_Text _progressText;
  private LevelManager _levelManager;

  public void Start()
  {
    _levelManager = FindObjectOfType<LevelManager>();
  }

  public void Update()
  {
    if (_levelManager.levelLoadingOperation == null) return;
    float progress = _levelManager.levelLoadingOperation.progress / 0.9f;
    _loadingSlider.value = progress;
    _progressText.text = $"{Mathf.Clamp01(progress) * 100 }%";
  }
}
