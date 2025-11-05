using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
	private static CoinManager instance;
	public int coins = 200;
	public Text coinLabel;

	void Start()
	{
		instance = this;
		UpdateCoinLabelText();
	}
	
	public void UpdateCoinLabelText()
	{
		coinLabel.text = string.Format("My Coins : {0}", coins.ToString());
	}

	public static int SpendCoins(int value)
	{
		if (instance.coins >= value)
		{
			instance.coins -= value;
			instance.UpdateCoinLabelText();
			return GetCoins();
		}
		else
		{
			return -1;
		}
	}
	public static int GainCoins(int value)
	{
		instance.coins += value;
		instance.UpdateCoinLabelText();
		return GetCoins();
	}
	public static int GetCoins()
	{
		return instance.coins;
	}
}
