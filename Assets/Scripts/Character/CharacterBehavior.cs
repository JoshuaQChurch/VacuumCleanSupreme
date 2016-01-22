using UnityEngine;
using System.Collections;

namespace VGDC.Character {

	public class CharacterBehavior : MonoBehaviour {

		private string name;

		public string getName(){
			return name;
		}

		void Start(){
			name = "";
		}

	}

}