using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
	public class CommandSpawnCube : ConsoleCommand {

		public override string Name { get; protected set; } // Name of Command
		public override string Command { get; protected set; } // The Command that gets typed into Console
		public override string Description { get; protected set; } // Description of Command
		public override string Help { get; protected set; } // Show Description of Command

		// Constructor
		public CommandSpawnCube(){
			Name = "Spawn Cube";
			Command = "/spawncube";
			Description = "Spawns a Cube";
			Help = "Use this command to spawn a cube";

			AddCommandToConsole ();
		}

		public override void RunCommand(){

			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			Renderer rend = cube.GetComponent<Renderer> ();
			Shader shader = Shader.Find ("Standard");
			rend.material.color = Color.green;
			rend.material.shader = shader;
			cube.transform.position = new Vector3 (0, 0, 0);
		}

		public static CommandSpawnCube CreateCommand(){
			return new CommandSpawnCube ();
		}
	}
}


