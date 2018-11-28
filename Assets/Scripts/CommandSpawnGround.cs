using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandSpawnGround : ConsoleCommand {

        public override string Name { get; protected set; } // Name of Command
        public override string Command { get; protected set; } // The Command that gets typed into Console
        public override string Description { get; protected set; } // Description of Command
        public override string Help { get; protected set; } // Show Description of Command
        public Material mat;

        // Constructor
        public CommandSpawnGround()
        {
            Name = "Spawn Ground";
            Command = "/spawnground";
            Description = "Spawns the ground";
            Help = "Use this command to spawn the ground";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {

            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Renderer rend = plane.GetComponent<Renderer>();
            Shader shader = Shader.Find("Standard");
            plane.AddComponent<MeshCollider>();
            rend.material = mat;
            if (shader)
            {
                rend.material.shader = shader;
            }
            else
            {
                plane.transform.localScale = new Vector3(3, 3, 3);
            }

            plane.transform.position = new Vector3(0, -2, 0);
            plane.transform.localScale = new Vector3(10, 10, 10);
        }

        public static CommandSpawnGround CreateCommand()
        {
            return new CommandSpawnGround();
        }
    }
}

