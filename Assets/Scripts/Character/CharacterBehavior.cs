using UnityEngine;
using System.Collections;

namespace VGDC.Character {

	public abstract class CharacterBehavior : MonoBehaviour {

		private string characterName;

		public string getName(){
			return characterName;
		}

		void Start(){
			characterName = "";
		}

	}

}