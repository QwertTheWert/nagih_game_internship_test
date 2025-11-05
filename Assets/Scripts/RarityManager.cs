using System;
using UnityEngine;

public enum Rarity
{
	Metal,
	Bronze,
	Silver,
	Gold,
	Diamond
}
public class RarityManager : MonoBehaviour
{
	private static RarityManager instance;
	[SerializeField] private RarityObject metal;
	[SerializeField] private RarityObject bronze;
	[SerializeField] private RarityObject silver;
	[SerializeField] private RarityObject gold;
	[SerializeField] private RarityObject diamond;

	void Start()
	{
		instance = this;
	}

	public static string GetName(Rarity rarity)
	{
		return Enum.GetName(typeof(Rarity), rarity);
	}

	public static int GetValue(Rarity rarity)
	{
		RarityObject obj = GetRarity(rarity);
		return obj != null ? obj.value : -1;
	}

	public static RarityObject GetRarity(Rarity rarity)
	{
		return rarity switch
		{
			Rarity.Metal => instance.metal,
			Rarity.Bronze => instance.bronze,
			Rarity.Silver => instance.silver,
			Rarity.Gold => instance.gold,
			Rarity.Diamond => instance.diamond,
			_ => null,
		};
	}
}
