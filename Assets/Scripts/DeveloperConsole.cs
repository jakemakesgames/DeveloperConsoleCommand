using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Console
{
	public abstract class ConsoleCommand
	{
		public abstract string Name { get; protected set; } // Name of Command
		public abstract string Command { get; protected set; } // The Command that gets typed into Console
		public abstract string Description { get; protected set; } // Description of Command
		public abstract string Help { get; protected set; } // Show Description of Command

		public void AddCommandToConsole(){
			string addMessage = " command has been added to the console.";
			DeveloperConsole.AddCommandsToConsole (Command, this);
			DeveloperConsole.AddStaticMessageToConsole (Name + addMessage);
		}

		public abstract void RunCommand ();
	}

	public class DeveloperConsole : MonoBehaviour {

		public static DeveloperConsole Instance { get; private set; }
		public static Dictionary<string, ConsoleCommand> Commands { get; private set; }

		[Header("Components")]
		public Canvas consoleCanvas;
		public ScrollRect scrollRect;
		public Text consoleText;
		public Text inputText;
		public InputField consoleInput;
        public Material[] cubeMat;
        public Material groundMat;
        public GameObject thirdPersonController;

        private void Awake()
		{
			if (Instance != null) 
			{
				return;
			}

			Instance = this;
			Commands = new Dictionary<string, ConsoleCommand> ();  
		}

		private void Start(){
			// Set the Console Canvas gameObject to SetActive false
			consoleCanvas.gameObject.SetActive (false);
			CreateCommands ();
		}

		private void CreateCommands(){
			// All the command you want to create go here
			CommandQuit commandQuit = CommandQuit.CreateCommand ();
			CommandSpawnCube commandSpawnCube = CommandSpawnCube.CreateCommand ();
            CommandSpawnGround commandSpawnGround = CommandSpawnGround.CreateCommand();
            CommandSpawnThirdPersonController commandSpawnThirdPersonController = CommandSpawnThirdPersonController.CreateCommand();

            //for (int i = 0; i < cubeMat.Length; i++)
            //{
            //    cubeMat[i].color = Random.ColorHSV();
            //}

            commandSpawnCube.mat = cubeMat;

            //cubeMat[i].color = Color.green;
            

            groundMat.color = Color.white;
            commandSpawnGround.mat = groundMat;
		}

		public static void AddCommandsToConsole(string _name, ConsoleCommand _command){
			// If the Commands does not contain the name, add the name and commant to the Commands Dictionary
			if (!Commands.ContainsKey (_name)) {
				Commands.Add (_name, _command);
			}
		}

		private void Update(){
			// If the Back Quote button is pressed
			if (Input.GetKeyDown (KeyCode.BackQuote)) {
				// Set the Console Canvase to On (if off) or Off (in on)
				consoleCanvas.gameObject.SetActive (!consoleCanvas.gameObject.activeInHierarchy);
			}

			// If the Console Command window is Active
			if (consoleCanvas.gameObject.activeInHierarchy) {
				// If the Return key is pressed
				if (Input.GetKeyDown(KeyCode.Return)){
					// If the input text does NOT equal and empty string
					if (inputText.text != "") {
						// Add a message to the console
						AddMessageToConsole(inputText.text);
						ParseInput (inputText.text);
					}
				}
			}
		}

		private void AddMessageToConsole(string msg){
			// Add a message to the console and add a new line at the end of it
			consoleText.text += msg + "\n";
			scrollRect.verticalNormalizedPosition = 0f; // 1 = top, 0 = bottom
		}

		// Any class not related to the console calls "DeveloperConsole.AddStaticMessageToConsole" 
		// and they can send a message to the console
		public static void AddStaticMessageToConsole(string msg){
			// Access consoleText and scrollRect through the static instance
			DeveloperConsole.Instance.consoleText.text += msg + "\n";
			DeveloperConsole.Instance.scrollRect.verticalNormalizedPosition = 0f;
		}

		private void ParseInput(string input){
			// Separates string by spaces
			string[] _input = input.Split (null);

			// If the input string length is equal to 0 OR null
			if (_input.Length == 0 || _input == null) {
				// Add this message to the console
				AddMessageToConsole ("Command not recognised.");
				return;
			}
			// If the command is not in the dictionary/ isn't recognised, add the message
			if (!Commands.ContainsKey (_input [0])) {
				AddMessageToConsole ("Command not recognised.");
			// If it is recognised, Do the thing
			} else {
				// Call the Command Class and Run the Command
				Commands[_input[0]].RunCommand();
			}
		}

	}
}

