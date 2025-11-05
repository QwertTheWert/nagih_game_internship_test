using UnityEngine;
using UnityEngine.UI;

public class RarityChanceInput : MonoBehaviour
{
	[SerializeField] private RarityObject rarityObject; // The rarity this field is for
	private Text label;
	private InputField inputField;

	// Start is called before the first frame update
	void Start()
	{

		label = transform.Find("Label").GetComponent<Text>();
		// Automatically Generate Label name based on selected rarity
		label.text = rarityObject.name; 

		inputField = transform.Find("InputField").GetComponent<InputField>();
		inputField.onValueChanged.AddListener(delegate { ValueChanged(); });
		inputField.onValidateInput = (string input, int charIndex, char addedChar) =>
		{
			return ValidateInput(charIndex, addedChar);
		};
	}

	public void ValueChanged()
	{
		if (inputField.text.Length > 1)
		{ // Erase leading 0s for formatting, also prevent multiple leading 0s. 
			char[] charToTrim = { '0' };
			var result = inputField.text.TrimStart(charToTrim);
			inputField.text = (result.Length == 0) ? "0" : result;
		}
	}

	// Validate so that only number can be entered and that the first character can't be 0
	private char ValidateInput(int charIndex, char addedChar)
	{
		if ("0123456789".IndexOf(addedChar) != -1)
		{
			return addedChar;
		}
		else
		{
			return '\0';
		}
	}

	public int GetValue()
	{
		if (inputField.text == "")
		{
			return 0;
		} else
		{
			return int.Parse(inputField.text);
		}
		
	}

}
