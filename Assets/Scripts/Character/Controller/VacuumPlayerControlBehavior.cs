using UnityEngine;
using System.Collections;
using VGDC.Character;

namespace VGDC.Character.Controller {

	/// <summary>
	/// Used to listen to input from the player and then map that input to actions that
	/// the vacuum can perform.
	/// </summary>
	public class VacuumPlayerControlBehavior : CharacterControlBehavior {

		private VacuumBehavior vacuumControlling;

		/// <summary>
		/// Made to allow child classes to have their own start function without
		/// overwriting the base class's Start()
		/// </summary>
		protected override void controlerStart(){

			vacuumControlling = gameObject.GetComponent<VacuumBehavior> ();

		}


		/// <summary>
		/// Made to allow child classes to have their own update function without
		/// overwriting the base class's Update()
		/// </summary>
		protected override void controlerUpdate(){

			if (vacuumControlling == null) {
				Debug.LogWarning ("Trying to control an object that has no vacuum behavior attatched!");
				return;
			}

			if(Input.GetKeyUp(KeyCode.Tab)){
				vacuumControlling.boost ();
			}

		}

	}

}