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
		Invoke(nameof(AddRarityChanceInputs), 0.01f);
	}

	// Itterate through the input and add it to the list
	public void AddRarityChanceInputs()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			RarityChanceInput rci = child.GetComponent<RarityChanceInput>();
			if (rci)
			{
				rarityChanceInputs.Add(rci);
			}
		}
	}

	public static List<int> GetPullTreshold()
	{
		int accum = 0;
		List<int> pullTreshold = new();
		foreach (RarityChanceInput rc in instance.rarityChanceInputs)
		{
			int value = rc.GetValue();
			pullTreshold.Add(value + accum);
			accum += value;
		} 

		// Treshold for each rarity in order. Ex: [1, 1, 1] rarity means when the RNG is rolled, 
		// the value that must be reached to reach that result is [1, 2, 3] (RNG excludes 0 for simplicity)
		return pullTreshold;
	}
	
}
