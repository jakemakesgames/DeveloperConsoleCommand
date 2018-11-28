using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Console
{
    public class CommandSpawnThirdPersonController : ConsoleCommand
    {

        public override string Name { get; protected set; } // Name of Command
        public override string Command { get; protected set; } // The Command that gets typed into Console
        public override string Description { get; protected set; } // Description of Command
        public override string Help { get; protected set; } // Show Description of Command
        public Material[] mat;

        // Constructor
        public CommandSpawnThirdPersonController()
        {
            Name = "Spawn Third Person Controller";
            Command = "/spawnthirdpersoncontroller";
            Description = "Spawns a Third Person Controller";
            Help = "Use this command to spawn a third person controller";

            AddCommandToConsole();
        }

        public override void RunCommand()
        {
            //GameObject thirdPerson = GameObject.Instantiate(DeveloperConsole.thirdPersonController) as GameObject;
            DeveloperConsole dc = GameObject.FindObjectOfType<DeveloperConsole>();
            GameObject thirdPerson = GameObject.Instantiate(dc.thirdPersonController);

        }

        public static CommandSpawnThirdPersonController CreateCommand()
        {
            return new CommandSpawnThirdPersonController();
        }
    }
}

