using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventoryItem : MonoBehaviour
{
	private Image image;
	private Button button;
	private RarityObject rarityObject;

	void Start()
	{
		image = GetComponent<Image>();
		image.sprite = rarityObject.borderSprite;

		button = GetComponent<Button>();
		button.onClick.AddListener(Click);
	}

	void Click()
	{
		InventoryManager.Sell(rarityObject);
		Destroy(gameObject);
	}

	public void SetRarity(RarityObject obj)
	{
		rarityObject = obj;
	}
}
