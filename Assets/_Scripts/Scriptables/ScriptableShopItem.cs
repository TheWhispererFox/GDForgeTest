using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Scriptables/ShopItem", fileName = "New ShopItem")]
public class ScriptableShopItem : ScriptableObject
{
  private Guid guid;
  public Guid Guid
  {
    get
    {
      if (guid == Guid.Empty)
      {
        guid = System.Guid.NewGuid();
      }
      return guid;
    }
  }
  public float price = 0f;
  public Sprite icon;
}
