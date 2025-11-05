using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
	public GameObject inventoryItemPrefab;

	// Adding an item to the grid and setting its index in the grid
	public void AddItem(RarityObject rarity, int itemIndex)
	{
		GameObject itemInstance = Instantiate(inventoryItemPrefab);
		itemInstance.GetComponent<InventoryItem>().rarityObject = rarity;
		itemInstance.transform.SetParent(transform);
		itemInstance.transform.SetSiblingIndex(itemIndex);
	}

}
