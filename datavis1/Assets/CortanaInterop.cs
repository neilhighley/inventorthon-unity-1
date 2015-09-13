using System;
using UnityEngine;

public class CortanaInterop : MonoBehaviour
{
    public static string CortanaText;
    public static bool SpeechInProgress;

    public static event EventHandler SpeechRequested;
    public static void GetMeSomeVoice()
    {
        if (SpeechRequested != null && !SpeechInProgress)
        {
            SpeechRequested(null, null);
        }
    }
}