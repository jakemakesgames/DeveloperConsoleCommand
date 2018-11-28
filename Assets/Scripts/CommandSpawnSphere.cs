using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
	public class CommandSpawnSphere : ConsoleCommand {
		
		public override string Name { get; protected set; } // Name of Command
		public override string Command { get; protected set; } // The Command that gets typed into Console
		public override string Description { get; protected set; } // Description of Command
		public override string Help { get; protected set; } // Show Description of Command
		public Material[] mat;

		// Constructor
		public CommandSpawnSphere(){
			Name = "Spawn Sphere";
			Command = "/spawnsphere";
			Description = "Spawns a Sphere";
			Help = "Use this command to spawn a sphere";

			AddCommandToConsole ();
		}

		public override void RunCommand(){

			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			Renderer rend = sphere.GetComponent<Renderer> ();
			Shader shader = Shader.Find ("Standard");
			sphere.AddComponent<Rigidbody>();
			rend.material = mat[Random.Range(0, mat.Length)];
			if (shader){
				rend.material.shader = shader;
			}
			else {
				sphere.transform.localScale = new Vector3(3, 3, 3);
			}

			sphere.transform.position = new Vector3 (0, 5, 0);
		}

		public static CommandSpawnSphere CreateCommand(){
			return new CommandSpawnSphere ();
		}
	}
}