using UnityEngine;
using System;
using System.Collections;

public class Walking : MonoBehaviour {

    private Animator animator;
    
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//      var v = Input.GetAxis("Vertical");
		//      var h = Input.GetAxis("Horizontal");
		//if(v >= 0.03 )
		//	animator.SetTrigger("walk");
		//else
		//	animator.SetTrigger("run");

		if (!String.IsNullOrEmpty(CortanaUnityBehavior.AvatarCommand))
		{
			Debug.Log("CORTANA = " + CortanaUnityBehavior.AvatarCommand);
			animator.SetTrigger(CortanaUnityBehavior.AvatarCommand);
			CortanaUnityBehavior.AvatarCommand = null; // processed
		}
	}
	
}
