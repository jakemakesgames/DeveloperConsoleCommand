using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
	public class CommandSpawnFreeCam : ConsoleCommand 
	{
		public override string Name { get; protected set; } // Name of Command
		public override string Command { get; protected set; } // The Command that gets typed into Console
		public override string Description { get; protected set; } // Description of Command
		public override string Help { get; protected set; } // Show Description of Command

		public CommandSpawnFreeCam()
		{
			Name = "Spawn a Free Camera";
			Command = "/spawnfreecam";
			Description = "Spawns a Free Roaming Camera";
			Help = "Use this command to spawn a free roaming camera";

			AddCommandToConsole();
		}

		public override void RunCommand()
		{
			DeveloperConsole dc = GameObject.FindObjectOfType<DeveloperConsole>();
			GameObject freeCam = GameObject.Instantiate(dc.freeCam);

		}

		public static CommandSpawnFreeCam CreateCommand()
		{
			return new CommandSpawnFreeCam();
		}
		
	}
	
	
}