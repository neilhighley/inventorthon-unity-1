using System;
using Windows.ApplicationModel.Activation;

namespace CortanaUnity
{
    public class SpeechHelper
    {
        public static void HandleSpeechCommand(IActivatedEventArgs args)
        {
            var commandArgs = args as Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;
            Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = commandArgs.Result;

            string textSpoken = speechRecognitionResult.Text;

            CortanaInterop.CortanaText = textSpoken;
        }
    }
}