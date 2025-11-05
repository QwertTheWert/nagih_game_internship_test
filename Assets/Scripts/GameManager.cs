using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Rarity
{
	Metal,
	Bronze,
	Silver,
	Gold,
	Diamond
}
public class GameManager : MonoBehaviour
{
	private static Dictionary<Rarity, int> rarityValues = new Dictionary<Rarity, int>
	{
		{Rarity.Metal, 10},
		{Rarity.Bronze, 20},
		{Rarity.Silver, 30},
		{Rarity.Gold, 40},
		{Rarity.Diamond, 50},
	};
	private static GameManager instance;

	public static int coins = 200;

	void Start()
	{
		instance = this;
	}

	public static string GetRarityName(Rarity rarity)
	{
		return System.Enum.GetName(typeof(Rarity), rarity);
	}

	public static int GetRarityValue(Rarity rarity)
	{
		return rarityValues[rarity];
	}

	public static int SpendCoins(int value)
	{
		if (value > coins)
		{
			coins -= value;
			return GetCoins();
		}
		else
		{
			return -1;
		}
	}
	public static int GainCoins(int value)
	{
		coins += value;
		return GetCoins();
	}
	public static int GetCoins()
	{
		return coins;
	}
}
