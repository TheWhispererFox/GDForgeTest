using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{
  [SerializeField] private TMP_Text _messageText;
  [SerializeField] private string _message;
  public string Message
  {
    get => _message;
    set
    {
      _message = value.Trim();
      _messageText.text = _message;
    }
  }
  void Start()
  {
    _messageText.text = _message.Trim();
  }
}
