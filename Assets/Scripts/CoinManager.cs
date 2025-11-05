using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
	private static CoinManager instance;
	public int coins = 200;

	void Start()
	{
		instance = this;
	}

	public static int Spend(int value)
	{
		if (instance.coins >= value)
		{
			instance.coins -= value;
			return Get();
		}
		else
		{
			return -1;
		}
	}
	public static int Gain(int value)
	{
		instance.coins += value;
		return Get();
	}
	public static int Get()
	{
		return instance.coins;
	}
}
