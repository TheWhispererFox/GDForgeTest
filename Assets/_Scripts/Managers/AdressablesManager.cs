using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Events;

public class AdressablesManager : MonoBehaviour
{

  [SerializeField] private AssetReference _cardAsset;
  [HideInInspector] public bool isInstantiated = false;
  public UnityEvent OnInstantiated;

  void Start()
  {
    Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
  }

  private void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
  {
    isInstantiated = true;
    OnInstantiated?.Invoke();
  }
}
