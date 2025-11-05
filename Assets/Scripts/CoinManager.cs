using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
	private static CoinManager instance;
	private int coins = 200;
	public Text coinLabel;

	void Start()
	{
		instance = this;
		UpdateCoinLabelText();
	}
	
	// Modify counter above button
	public void UpdateCoinLabelText()
	{
		coinLabel.text = string.Format("My Coins : {0}", coins.ToString());
	}

	// Reduce count
	public static int SpendCoins(int value)
	{
		if (instance.coins >= value)
		{
			instance.coins -= value; // Reduce value
			instance.UpdateCoinLabelText(); // Update text
			return GetCoins(); // Return remaining coin value as int
		}
		else
		{
			return -1; // The return value if you dont have enough money to pull
		}
	}

	// Incrase Coins
	public static int GainCoins(int value)
	{
		instance.coins += value; // Increase Value
		instance.UpdateCoinLabelText(); // Update Text
		return GetCoins(); // Return new value as int
	}

	// Get the current coin value as a function since coins is a private variable
	public static int GetCoins()
	{
		return instance.coins;
	}
}
