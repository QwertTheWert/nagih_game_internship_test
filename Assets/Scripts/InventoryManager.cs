using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	public Text inventoryLabel;
	public InventoryGrid grid;
	private static InventoryManager instance;
	private Dictionary<RarityObject, int> inventory = new();

	// Start is called before the first frame update
	void Start()
	{
		instance = this;
		Invoke(nameof(PopulateInventory), 0.01f);
	}

	// Add to the keys for the dictioanry that count how many of each item you have
	void PopulateInventory()
	{
		AddToInventory(Rarity.Metal);
		AddToInventory(Rarity.Bronze);
		AddToInventory(Rarity.Silver);
		AddToInventory(Rarity.Gold);
		AddToInventory(Rarity.Diamond);
	}

	void AddToInventory(Rarity rarity)
	{
		inventory.Add(RarityManager.GetRarity(rarity), 0);
	}

	// When item is gained/sold update the inventory label
	void UpdateInventoryLabel(int value)
	{
		inventoryLabel.text = string.Format("Storage Coin Value : {0}", value.ToString());
	}
	
	// Add item to inventory
	public static void Gain(RarityObject key)
	{
		instance.inventory[key] += 1; // Item of an X tpe has its value incrase by 1
		instance.UpdateInventoryLabel(GetTotalItemValue()); // Update the value counter
		// Find the index where the item should be put at, sorted from highest ratity to lowest rarity
		int rarityInt = (int)key.rarity;
		int itemIndex = 0;
		for (int i = rarityInt+1; i <= (int)Rarity.Diamond; i++)
		{
			itemIndex += instance.inventory[RarityManager.GetRarity((Rarity)i)];	
		}
		instance.grid.AddItem(key, itemIndex);
	}

	// Remove item from inventory
	public static void Sell(RarityObject key)
	{
		instance.inventory[key] -= 1; // Reduce amount from dictionary
		instance.UpdateInventoryLabel(GetTotalItemValue()); // Update value counter
		CoinManager.GainCoins(key.value); // Update coin value
	}
	
	// Calculate total item value
	public static int GetTotalItemValue()
	{
		int totalValue = 0;
		foreach (RarityObject key in instance.inventory.Keys)
		{
			totalValue += key.value * instance.inventory[key];
		}
		return totalValue;
	}
}
