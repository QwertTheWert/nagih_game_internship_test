using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RarityInput : MonoBehaviour
{
	[SerializeField] private Rarity rarity;
	private Text label;
	private InputField inputField;

	// // Start is called before the first frame update
	// void Start()
	// {
	// 	label = transform.Find("Label").GetComponent<Text>();
	// 	label.text = GameManager.GetRarityName(rarity);

	// 	inputField = transform.Find("InputField").GetComponent<InputField>();
	// 	// inputField.onValueChanged.AddListener(delegate { ValueChanged(); });
	// 	inputField.onValidateInput = (string input, int charIndex, char addedChar) =>
	// 	{
	// 		return ValidateInput(charIndex, addedChar);
	// 	};
	// }

	// // void ValueChanged()
	// // {
	// // 	if (inputField.text.Length > 1)
	// // 	{
	// // 		char[] charsToTrim = { '0' };
	// // 		inputField.text = inputField.text.TrimStart(charsToTrim);
	// // 	}
	// // }

	// private char ValidateInput(int charIndex, char addedChar)
	// {
	// 	Debug.Log(addedChar);
	// 	if ("0123456789".IndexOf(addedChar) != 0 && !(addedChar == '0' && charIndex == 0))
	// 	{
	// 		return addedChar;
	// 	}
	// 	else
	// 	{
	// 		return '\0';
	// 	}
	// }
	
}
