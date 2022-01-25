using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ShopController : MonoBehaviour
{
  [SerializeField] private AssetReference _cardPrefabReference;
  [SerializeField] private Transform _shopContent;
  [SerializeField] private Animator _shopAnimator;
  private List<ScriptableShopItem> _items;
  void Start()
  {
    _items = ResourceSystem.Instance.shopItems;
    foreach (var item in _items)
    {
      AddShopItem(item);
    }
  }

  public void AddShopItem(ScriptableShopItem item)
  {
    if (item == null) return;
    _cardPrefabReference.InstantiateAsync().Completed += (cardOp) =>
    {
      var card = cardOp.Result;
      card.GetComponent<CardController>().ShopItem = item;
      card.transform.SetParent(_shopContent);
    };
  }

  public void ReplaceShopItem(System.Guid guid, ScriptableShopItem item)
  {
    if (item == null) return;
    var card = _shopContent.GetComponentsInChildren<CardController>().Single(c => c.ShopItem.Guid == item.Guid);
    int index = _items.FindIndex(i => i.Guid == guid);
    if (index != -1) _items[index] = item;
    card.ShopItem = item;
  }

  public void RemoveShopItem(ScriptableShopItem item)
  {
    if (item == null) return;
    var card = _shopContent.GetComponentsInChildren<CardController>().Where(c => c.ShopItem.Guid == item.Guid).Single();
    card.transform.SetParent(null);
    card.transform.DestroyChildren();
    Destroy(card.gameObject);
    _items.Remove(item);
  }

  public void CloseShop()
  {
    _shopAnimator.SetTrigger("Close");
  }
}
