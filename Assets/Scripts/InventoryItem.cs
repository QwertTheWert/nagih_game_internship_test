using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class InventoryItem : MonoBehaviour
{
	private Image image;
	private Button button;
	public RarityObject rarityObject;

	void Start()
	{   // Set frame
		image = GetComponent<Image>();
		image.sprite = rarityObject.borderSprite;

		button = GetComponent<Button>();
		button.onClick.AddListener(Click);
	}

	// Sell on click
	void Click()
	{
		InventoryManager.Sell(rarityObject);
		Destroy(gameObject);
	}
}