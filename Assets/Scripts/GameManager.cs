using UnityEngine;

public class GameOverManager : MonoBehaviour
{ // This script only exists to check if the game is over, 
	static void CheckIfGameOver()
	{
		int sumValue = CoinManager.GetCoins() + InventoryManager.GetTotalItemValue();
		if (sumValue < 30)
		{
			Debug.Log("Game Over");
		}
	}

}
