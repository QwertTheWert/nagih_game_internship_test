using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
	public GameObject inventoryItemPrefab;
	// Start is called before the first frame update
	void Start()
	{

	}

	public void AddItem(RarityObject rarity, int itemIndex)
	{
		GameObject itemInstance = Instantiate(inventoryItemPrefab);
		itemInstance.GetComponent<InventoryItem>().SetRarity(rarity);
		itemInstance.transform.SetParent(transform);
		itemInstance.transform.SetSiblingIndex(itemIndex);
	}

}
