using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaButton : MonoBehaviour
{
	[SerializeField] private int pullCost = 30;
	private Button btn;
    // Start is called before the first frame update
    void Start()
    {
		btn = GetComponent<Button>();
		btn.onClick.AddListener(PullGacha);
    }

    // Update is called once per frame
    void PullGacha()
    {
		if (GameManager.SpendCoins(pullCost) != -1)
		{
			
		};
    }
}
