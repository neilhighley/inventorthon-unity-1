using System;
using System.Collections.Generic;
using UnityEngine;

public class CortanaUnityBehavior : MonoBehaviour {

    public static string Text;
	public static string AvatarCommand;

    public static bool IsSpeaking;

	public static event EventHandler OnStartSpeaking;
	public static event EventHandler OnStopSpeaking;

	public static void StartSpeaking(Dictionary<string, string> qaList)
	{
		if (OnStartSpeaking != null && !IsSpeaking)
		{
			OnStartSpeaking(qaList, null);
		}
		IsSpeaking = true;
	}

	public static void StopSpeaking()
	{
		if (OnStopSpeaking != null && IsSpeaking)
		{
			OnStopSpeaking(null, null);
		}
		IsSpeaking = false;
	}

}
