using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
	public class CommandQuit : ConsoleCommand {

		public override string Name { get; protected set; } // Name of Command
		public override string Command { get; protected set; } // The Command that gets typed into Console
		public override string Description { get; protected set; } // Description of Command
		public override string Help { get; protected set; } // Show Description of Command

		// Constructor
		public CommandQuit(){
			Name = "Quit Application";
			Command = "/quitapplication";
			Description = "Quits the application";
			Help = "Use this command to force the application to quit";

			AddCommandToConsole ();
		}

		public override void RunCommand(){

			// Quit the Application
			if (Application.isEditor) {
				#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
				#endif
			} else {
				Application.Quit ();
			}
		}

		// Put this in every Command we make and name it specific to the Command it is in
		public static CommandQuit CreateCommand(){
			
			return new CommandQuit ();
		}
	}
}

