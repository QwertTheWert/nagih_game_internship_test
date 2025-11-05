using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GachaButton : MonoBehaviour
{
	[SerializeField] private int pullCost = 30;
	private Button btn;

	// Start is called before the first frame update
	void Start()
	{
		btn = transform.Find("Button").GetComponent<Button>();
		btn.onClick.AddListener(ValidateGachaPull);
	}

	// On click, check if you can even gacha
	void ValidateGachaPull()
	{
		List<int> pullTreshold = RarityChanceController.GetPullTreshold();
		if (ValidatePercentageArray(pullTreshold)) // Check the % value to see if its not all 0
		{
			if (CoinManager.SpendCoins(pullCost) != -1) // Check if you have the money
			{
				RarityObject result = GachaPull(pullTreshold);
				if (result) // Result should never be empty by this point but just in case, added a validator 
				{
					InventoryManager.Gain(result); // Pull & add the item
					
				}
			}
		}
		else
		{
			Debug.Log("Invalid percentages: total cannot be zero");
		}
	}

	// Check if the % is all 0 by checking if the last value is 0
	// since each value is a "treshold" you need to roll to get the item
	bool ValidatePercentageArray(List<int> pullTreshold)
	{
		return pullTreshold[pullTreshold.Count - 1] != 0;
	}

	// The code that handles how gacha pull is calculated
	RarityObject GachaPull(List<int> pullTreshold)
	{
		// You need to roll a number between a range to get a certain item.
		// Example: 20 metal, 20 bronze, 20 silver
		// 1-20 = metal, 21-40 = bronze, 41-60 = silver
		int maxValue = pullTreshold[pullTreshold.Count - 1];
		int resultInt = Random.Range(1, maxValue + 1);
		Debug.Log(resultInt);

		// Itterate through all rarity and see where the item lands
		for (int i = 0; i < 5; i++)
		{
			if (resultInt <= pullTreshold[i])
			{
				return RarityManager.GetRarity((Rarity)i);
			}

		}

		return null; // It should never get to this point but return null here just so that it runs
	}

}
