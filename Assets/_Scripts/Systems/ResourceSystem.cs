using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects.
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem>
{
  public List<ScriptableShopItem> shopItems { get; private set; }
  private Dictionary<string, ScriptableShopItem> _shopItemDict;

  protected override void Awake()
  {
    base.Awake();
    AssembleResources();
  }

  private void AssembleResources()
  {
    shopItems = Resources.LoadAll<ScriptableShopItem>("Scriptables/ShopItems").ToList();
    _shopItemDict = shopItems.ToDictionary(r => r.ToString(), r => r);
  }

  public ScriptableShopItem GetShopItem(string t) => _shopItemDict[t];
  public ScriptableShopItem GetRandomShopItem() => shopItems[Random.Range(0, shopItems.Count)];
}