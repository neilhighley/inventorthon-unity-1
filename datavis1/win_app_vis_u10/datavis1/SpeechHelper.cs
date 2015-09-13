using System;
using CortanaUnity;
using Windows.ApplicationModel.Activation;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UnityPlayer;

namespace CortanaUnity
{
    public class SpeechHelper
    {
        private static Windows.Media.SpeechRecognition.SpeechRecognizer speechRecognizer;
        private static Windows.Media.SpeechSynthesis.SpeechSynthesizer synth;
        private static MediaElement mediaElement;

        public static void HandleSpeechCommand(IActivatedEventArgs args)
        {
            var commandArgs = args as Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;
            Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = commandArgs.Result;

            // If so, get the name of the voice command, the actual text spoken, and the value of Command/Navigate@Target.
            string voiceCommandName = speechRecognitionResult.RulePath[0];
            string textSpoken = speechRecognitionResult.Text;
            string navigationTarget = speechRecognitionResult.SemanticInterpretation.Properties["NavigationTarget"][0];

			if (!String.IsNullOrEmpty(textSpoken))
			{
				CortanaUnityBehavior.Text = textSpoken;
				switch (voiceCommandName)
				{
					case "playerActions":
						CortanaUnityBehavior.AvatarCommand = textSpoken;
						break;
					default:
						// There is no match for the voice command name.
						break;
				}
			}
        }
        public static async System.Threading.Tasks.Task InitialiseSpeechRecognition()
        {
            // Create an instance of SpeechRecognizer.
            speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

            // Add a web search grammar to the recognizer.
            var dictationGrammar = new Windows.Media.SpeechRecognition.SpeechRecognitionTopicConstraint(Windows.Media.SpeechRecognition.SpeechRecognitionScenario.Dictation, "dication");


            speechRecognizer.UIOptions.AudiblePrompt = "Please give us your feedback...";
            speechRecognizer.UIOptions.ExampleText = @"This game is awesome, rate me 5 stars";
            speechRecognizer.UIOptions.IsReadBackEnabled = false;
            speechRecognizer.Constraints.Add(dictationGrammar);

            // Compile the dictation grammar by default.
            await speechRecognizer.CompileConstraintsAsync();
        }

        public static async void StartRecognizing(object sender, EventArgs e)
        {
			CortanaUnityBehavior.IsSpeaking = true;

            // Start recognition.
            Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();

			// Do something with the recognition result.
			CortanaUnityBehavior.Text = speechRecognitionResult.Text;
			CortanaUnityBehavior.IsSpeaking = false;
        }

        public static void InitialiseSpeechSynthesis(MediaElement MediaElement)
        {
            // The media object for controlling and playing audio.
            mediaElement = MediaElement;

            // The object for controlling the speech synthesis engine (voice).
            synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();

        }

        public static async void StartSpeaking(object sender, EventArgs e)
        {
            var textToSpeech = (string)sender;
            if (mediaElement != null && !string.IsNullOrEmpty(textToSpeech))
            {
                // Generate the audio stream from plain text.
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(textToSpeech);
                (Application.Current as Template.App).appCallbacks.InvokeOnUIThread(() => {
					// Send the stream to the media object.
					mediaElement.SetSource(stream, stream.ContentType);
					mediaElement.Play();
				}, true);
            }

        }
    }
}
