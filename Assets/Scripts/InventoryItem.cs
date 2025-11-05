using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventoryItem : MonoBehaviour
{
	private Image image;
	private RarityObject rarityObject;

	void Start()
	{
		image = GetComponent<Image>();
		image.sprite = rarityObject.borderSprite;
	}

	public void SetRarity(RarityObject obj)
	{
		rarityObject = obj;
	}
}
