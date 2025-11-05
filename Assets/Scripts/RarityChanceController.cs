using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RarityChanceController : MonoBehaviour
{
	private static RarityChanceController instance;
	private List<RarityChanceInput> rarityChanceInputs = new();
	
	// Start is called before the first frame update
	void Awake()
	{
		instance = this;
	}

	public static void AddRarityChanceInputs(RarityChanceInput pr)
	{
		instance.rarityChanceInputs.Add(pr);
	}

	public static List<int> GetPullTreshold()
	{
		int accum = 0;
		List<int> pullTreshold = new();
		foreach (RarityChanceInput rp in instance.rarityChanceInputs)
		{
			int value = rp.GetValue();
			pullTreshold.Add(value + accum);
			accum += value;
		} 

		// Treshold for each rarity in order. Ex: [1, 1, 1] rarity means when the RNG is rolled, 
		// the value that must be reached to reach that result is [1, 2, 3] (RNG excludes 0 for simplicity)
		return pullTreshold;
	}
	
}
