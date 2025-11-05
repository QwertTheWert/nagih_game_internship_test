using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static void CheckIfGameOver()
	{
		int sumValue = CoinManager.GetCoins() + InventoryManager.GetTotalItemValue();
		if (sumValue < 30)
		{
			Debug.Log("Game Over");
		}
	}

}
