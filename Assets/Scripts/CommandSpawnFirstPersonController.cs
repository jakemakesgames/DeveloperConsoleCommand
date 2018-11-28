using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandSpawnFirstPersonController : ConsoleCommand
    {
        public override string Name { get; protected set; } // Name of Command
        public override string Command { get; protected set; } // The Command that gets typed into Console
        public override string Description { get; protected set; } // Description of Command
        public override string Help { get; protected set; } // Show Description of Command
        public Material[] mat;

        // Constructor
        public CommandSpawnFirstPersonController()
        {
            Name = "Spawn First Person Controller";
            Command = "/spawnfirstpersoncontroller";
            Description = "Spawns a First Person Controller";
            Help = "Use this command to spawn a first person controller";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {
            //GameObject thirdPerson = GameObject.Instantiate(DeveloperConsole.thirdPersonController) as GameObject;
            DeveloperConsole dc = GameObject.FindObjectOfType<DeveloperConsole>();
            GameObject firstPerson = GameObject.Instantiate(dc.firstPersonController);

        }

        public static CommandSpawnFirstPersonController CreateCommand()
        {
            return new CommandSpawnFirstPersonController();
        }
    }
}

