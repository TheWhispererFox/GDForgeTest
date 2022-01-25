using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using SFB;

public class ManageShopItemController : MonoBehaviour
{
  [SerializeField] private TMP_InputField _nameInput;
  [SerializeField] private TMP_InputField _priceInput;
  [SerializeField] private Image _imagePreview;
  [SerializeField] private Animator _manageItemAnimator;
  [SerializeField] private Sprite _imagePlaceholder;
  [SerializeField] private ShopController _shop;
  private ScriptableShopItem _item;
  private Sprite _icon;
  public void OnLoadImage()
  {
    StartCoroutine(LoadImageFileRoutine());
  }

  IEnumerator LoadImageFileRoutine()
  {
    string path = StandaloneFileBrowser.OpenFilePanel("Load Image", "", new ExtensionFilter[] { new ExtensionFilter("Image Files", "png", "jpg", "jpeg") }, false)[0];
    if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
    {
      using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture($"file://{path}"))
      {
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError ||
            uwr.result == UnityWebRequest.Result.ProtocolError)
        {
          Debug.Log(uwr.error);
        }
        else
        {
          var texture = DownloadHandlerTexture.GetContent(uwr);
          _icon = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
          _imagePreview.sprite = _icon;
          if (_item != null) _item.icon = _icon;
        }
      }
    }
  }

  public void OnSave()
  {
    bool isEdit = false;

    if (_item == null)
      _item = ScriptableObject.CreateInstance<ScriptableShopItem>();
    else
      isEdit = true;

    _item.name = _nameInput.text.Trim();
    _item.price = float.Parse(_priceInput.text.Trim());
    if (_icon != null) _item.icon = _icon;

    if (isEdit)
      _shop.ReplaceShopItem(_item.Guid, _item);
    else
      _shop.AddShopItem(_item);

    Close();
  }

  public void Close()
  {
    _manageItemAnimator.SetTrigger("Close");
  }

  public void Delete()
  {
    if (_item != null) _shop.RemoveShopItem(_item);
    Close();
  }

  public void Open(Object item)
  {
    if (item != null && item is ScriptableShopItem)
    {
      _item = item as ScriptableShopItem;
      _nameInput.text = _item.name;
      _priceInput.text = _item.price.ToString();
      _imagePreview.sprite = _item.icon;
    }
    else
    {
      _nameInput.text = string.Empty;
      _priceInput.text = string.Empty;
      _imagePreview.sprite = _imagePlaceholder;
    }
    _manageItemAnimator.SetTrigger("Open");
  }
}
