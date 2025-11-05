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
	
	void UpdateInventoryLabel(int value)
	{
		inventoryLabel.text = string.Format("Storage Coin Value : {0}", value.ToString());
	}

	public static void Gain(RarityObject key)
	{
		instance.inventory[key] += 1;
		instance.UpdateInventoryLabel(GetTotalItemValue());
		int rarityInt = (int)key.rarity;
		int itemIndex = 0;
		for (int i = rarityInt+1; i <= (int)Rarity.Diamond; i++)
		{
			itemIndex += instance.inventory[RarityManager.GetRarity((Rarity)i)];	
		}
		instance.grid.AddItem(key, itemIndex);
	}

	public static void Sell(RarityObject key)
	{
		instance.inventory[key] -= 1;
		instance.UpdateInventoryLabel(GetTotalItemValue());
		CoinManager.GainCoins(key.value);
	}
	
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
