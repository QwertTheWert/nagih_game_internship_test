using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RarityPercentageInput : MonoBehaviour
{
	[SerializeField] private Rarity rarity; // The rarity this field is for
	private Text label;
	private InputField inputField;

	// Start is called before the first frame update
	void Start()
	{
		label = transform.Find("Label").GetComponent<Text>();
		label.text = GameManager.GetRarityName(rarity); // Automatically Generate Label name based on selected rarity

		inputField = transform.Find("InputField").GetComponent<InputField>();
		inputField.onValidateInput = (string input, int charIndex, char addedChar) =>
		{
			return ValidateInput(charIndex, addedChar);
		};
	}

	// Validate so that only number can be entered and that the first character can't be 0
	private char ValidateInput(int charIndex, char addedChar)
	{
		if ("0123456789".IndexOf(addedChar) != -1 && !(addedChar == '0' && charIndex == 0))
		{
			return addedChar;
		}
		else
		{
			return '\0';
		}
	}
	
}
