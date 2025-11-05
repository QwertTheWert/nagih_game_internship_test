using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GachaButton : MonoBehaviour
{
	[SerializeField] private int pullCost = 30;
	[SerializeField] private CoinManager coinManager;
	private Text coinLabel;
	private Button btn;

	// Start is called before the first frame update
	void Start()
	{
		btn = transform.Find("Button").GetComponent<Button>();
		btn.onClick.AddListener(ValidateGachaPull);

		coinLabel = transform.Find("CoinLabel").GetComponent<Text>();
		UpdateCoinLabelText();
	}
	
	void ValidateGachaPull()
	{
		List<int> pullTreshold = RarityChanceController.GetPullTreshold();
		if (ValidatePercentageArray(pullTreshold))
		{
			if (CoinManager.Spend(pullCost) != -1)
			{
				RarityObject result = GachaPull(pullTreshold);
				UpdateCoinLabelText();
				Debug.Log(result);
			} else
			{
				Debug.Log("NO MONEY!!!!");
			}
		}
		else
		{
			Debug.Log("Invalid percentages: total cannot be zero");
		}
	}

	bool ValidatePercentageArray(List<int> arr)
	{
		return arr[^1] != 0;
	}

RarityObject GachaPull(List<int> pullTreshold)
	{
		int maxValue = pullTreshold[^1];
		int resultInt = Random.Range(1, maxValue + 1);
		if (resultInt <= pullTreshold[0])
		{
			return RarityManager.GetRarity(Rarity.Metal);
		}
		else if (resultInt <= pullTreshold[1])
		{
			return RarityManager.GetRarity(Rarity.Bronze);
		}
		else if (resultInt <= pullTreshold[2])
		{
			return RarityManager.GetRarity(Rarity.Silver);
		}
		else if (resultInt <= pullTreshold[3])
		{
			return RarityManager.GetRarity(Rarity.Gold);
		}
		else
		{
			return RarityManager.GetRarity(Rarity.Diamond);
		}
	}
	
	void UpdateCoinLabelText()
	{
		coinLabel.text = string.Format("My Coins : {0}", coinManager.coins);
	}


}
