using UnityEngine;
using System.Collections;
using VGDC.GameManagement;
using VGDC.Character;

namespace VGDC.Prototyping {

	public class ExampleGameMode : GameMode {

		private int[] playerKills = null;

		public override void onGameStart(){

			// Do what you want when you 

			// initialize player kills to 0.
		}


		public override void onCharacterDeath(CharacterBehavior character){

			Debug.Log (character.getName()+" has died!");

		}


		public override void onCharacterAdd(CharacterBehavior character){

			Debug.Log (character.getName() + " has been added to the scene!");

		}


	}

}