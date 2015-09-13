using UnityEngine;
using System;
using System.Collections;

public class UpdateAvatar : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!String.IsNullOrEmpty(CortanaUnityBehavior.AvatarCommand))
		{
			Debug.Log("CORTANA = " + CortanaUnityBehavior.AvatarCommand);
			anim.SetTrigger(CortanaUnityBehavior.AvatarCommand);
			CortanaUnityBehavior.AvatarCommand = null; // processed
		}
	}
}
