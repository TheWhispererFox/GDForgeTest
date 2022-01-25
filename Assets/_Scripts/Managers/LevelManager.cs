using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public AsyncOperation levelLoadingOperation;
  public void LoadLevel(int sceneIndex)
  {
    levelLoadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
  }
  void Start()
  {
    LoadLevel(1);
  }
}
