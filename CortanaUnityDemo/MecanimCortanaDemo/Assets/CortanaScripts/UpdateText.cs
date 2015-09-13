using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UpdateText : MonoBehaviour {

	Text textLabel;

	// Use this for initialization
	void Start()
	{
		textLabel = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!String.IsNullOrEmpty(CortanaUnityBehavior.Text))
		{
			textLabel.text = CortanaUnityBehavior.Text;
		}
	}
}
