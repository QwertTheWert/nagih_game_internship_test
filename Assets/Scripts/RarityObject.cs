using UnityEngine;

[CreateAssetMenu(fileName="RarityObject", menuName="ScriptableObjects/RarityObject")]
public class RarityObject : ScriptableObject
{
	public int value;
	public Rarity rarity;
	public Sprite borderSprite;
}
