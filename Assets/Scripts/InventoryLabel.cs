using UnityEngine;
using UnityEngine.UI;

public class InventoryLabel : MonoBehaviour
{
	private Text label;

	// Start is called before the first frame update
	void Start()
	{
		label = GetComponent<Text>();
	}

	public void SetText(int value)
	{
		label.text = string.Format("Storage Coin Value : {0}", value.ToString());
	}


}
