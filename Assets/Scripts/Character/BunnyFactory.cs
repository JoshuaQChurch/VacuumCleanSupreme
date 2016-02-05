using UnityEngine;
using System.Collections;
using VGDC.GameManagement;

namespace VGDC.Character {

	/// <summary>
	/// Bunny factory, used for encapsulating creation logic of a bunny and what
	/// ever else goes with networking
	/// </summary>
	public static class BunnyFactory {


		/// <summary>
		/// Creates a bunny in the scene and makes sure the game manager know's of it's
		/// existance.
		/// </summary>
		/// <returns>The bunny.</returns>
		/// <param name="position">Position.</param>
		public static GameObject createBunny(Vector3 position){

			GameObject bunny = (GameObject)GameObject.Instantiate (Resources.Load<GameObject>("Character/Bunny"), position, Quaternion.identity);

			GameManager.getInstance ().addCharacterToGame (bunny.GetComponent<BunnyBehavior>());

			return bunny;

		}

	}

}