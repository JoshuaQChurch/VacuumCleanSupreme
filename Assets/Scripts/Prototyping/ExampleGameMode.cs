using UnityEngine;
using System.Collections;
using VGDC.GameManagement;
using VGDC.Character;

namespace VGDC.Prototyping {

	public class ExampleGameMode : MonoBehaviour,GameMode {

		private int[] playerKills = null;

		public void onGameStart(){

			// Do what you want when you 

			// initialize player kills to 0.
		}


		public void onCharacterDeath(CharacterBehavior character){

			Debug.Log (character.getName()+" has died!");

		}


		public void onCharacterAdd(CharacterBehavior character){

			Debug.Log (character.getName() + " has been added to the scene!");

		}


	}

}