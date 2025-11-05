using System.Collections;
using System.Collections.Generic;
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
	private static GameManager instance;

	void Start()
	{
		instance = this;
	}

	public static string GetRarityName(Rarity rarity)
	{
		return System.Enum.GetName(typeof(Rarity), rarity);
	}

}
