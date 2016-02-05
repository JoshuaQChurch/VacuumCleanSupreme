using UnityEngine;
using System.Collections;
using VGDC.Character;

namespace VGDC.Character.Controller {

	/// <summary>
	/// Used to listen to input from the player and then map that input to actions that
	/// the bunny can perform.
	/// </summary>
	public class BunnyPlayerControlBehavior : CharacterControlBehavior {

		private BunnyBehavior bunnyControlling;

		/// <summary>
		/// Made to allow child classes to have their own start function without
		/// overwriting the base class's Start()
		/// </summary>
		protected override void controlerStart(){

			bunnyControlling = gameObject.GetComponent<BunnyBehavior> ();

		}


		/// <summary>
		/// Made to allow child classes to have their own update function without
		/// overwriting the base class's Update()
		/// </summary>
		protected override void controlerUpdate(){

			if (bunnyControlling == null) {
				Debug.LogWarning ("Trying to control an object that has no bunny behavior attatched!");
				return;
			}

			if(Input.GetKeyUp(KeyCode.E)){
				bunnyControlling.layTrap ();
			}

		}

	}

}