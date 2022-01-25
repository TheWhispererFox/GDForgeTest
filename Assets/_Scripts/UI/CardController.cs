using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardController : MonoBehaviour
{
  [SerializeField] private Image _iconImage;
  [SerializeField] private TMP_Text _nameText;
  [SerializeField] private TMP_Text _priceText;
  [SerializeField] private ScriptableShopItem _shopItem;
  [SerializeField] private Button _editBtn;
  public ScriptableShopItem ShopItem
  {
    get => _shopItem;
    set
    {
      _shopItem = value;
      _nameText.text = value.name;
      _priceText.text = $"Cost: {value.price}$";
      _iconImage.sprite = value.icon;
    }
  }
  void Start()
  {
    _nameText.text = _shopItem.name;
    _priceText.text = $"Cost: {_shopItem.price}$";
    _iconImage.sprite = _shopItem.icon;
  }

  public void OnEditBtnClick()
  {
    var itemsManager = FindObjectOfType<ManageShopItemController>();
    itemsManager.Open(ShopItem);
  }
}
