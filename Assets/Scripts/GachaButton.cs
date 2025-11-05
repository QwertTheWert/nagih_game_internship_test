using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GachaButton : MonoBehaviour
{
	[SerializeField] private int pullCost = 30;
	[SerializeField] private CoinManager coinManager;
	private Button btn;

	// Start is called before the first frame update
	void Start()
	{
		btn = transform.Find("Button").GetComponent<Button>();
		btn.onClick.AddListener(ValidateGachaPull);
	}
	
	void ValidateGachaPull()
	{
		List<int> pullTreshold = RarityChanceController.GetPullTreshold();
		if (ValidatePercentageArray(pullTreshold))
		{
			if (CoinManager.SpendCoins(pullCost) != -1)
			{
				
				InventoryManager.Gain(GachaPull(pullTreshold));
			}
		}
		else
		{
			Debug.Log("Invalid percentages: total cannot be zero");
		}
	}

	bool ValidatePercentageArray(List<int> pullTreshold)
	{
		return pullTreshold[pullTreshold.Count - 1] != 0;
	}

RarityObject GachaPull(List<int> pullTreshold)
	{
		int maxValue = pullTreshold[pullTreshold.Count - 1];
		int resultInt = Random.Range(1, maxValue + 1);
		Debug.Log(resultInt);

		if (resultInt <= pullTreshold[(int) Rarity.Metal])
		{
			return RarityManager.GetRarity(Rarity.Metal);
		}
		else if (resultInt <= pullTreshold[(int) Rarity.Bronze])
		{
			return RarityManager.GetRarity(Rarity.Bronze);
		}
		else if (resultInt <= pullTreshold[(int) Rarity.Silver])
		{
			return RarityManager.GetRarity(Rarity.Silver);
		}
		else if (resultInt <= pullTreshold[(int) Rarity.Gold])
		{
			return RarityManager.GetRarity(Rarity.Gold);
		}
		else
		{
			return RarityManager.GetRarity(Rarity.Diamond);
		}
	}
	
	

}
