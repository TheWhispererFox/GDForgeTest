using UnityEngine;
using UnityEngine.AddressableAssets;
using TMPro;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{
  [SerializeField] private Transform _chatContent;
  [SerializeField] private AssetReference _messagePrefabReference;
  [SerializeField] private TMP_InputField _messageInput;
  [SerializeField] private Animator _chatPanelAnimator;
  public void SendMessage()
  {
    _messagePrefabReference.InstantiateAsync().Completed += (handle) =>
    {
      var message = handle.Result.GetComponent<MessageController>();
      message.Message = _messageInput.text;
      message.transform.SetParent(_chatContent);
      // Weird fix with content not being resized in a right way
      Canvas.ForceUpdateCanvases();
      _chatContent.GetComponent<VerticalLayoutGroup>().enabled = false;
      _chatContent.GetComponent<VerticalLayoutGroup>().enabled = true;
      _messageInput.text = string.Empty;
    };
  }

  public void Open()
  {
    _chatPanelAnimator.SetTrigger("Open");
  }
  public void Close()
  {
    _chatPanelAnimator.SetTrigger("Close");
  }
}
