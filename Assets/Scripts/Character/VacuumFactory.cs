using UnityEngine;
using System.Collections;
using VGDC.GameManagement;

namespace VGDC.Character {

	/// <summary>
	/// Vacuum factory, used for encapsulating creation logic of a vacuum and what
	/// ever else goes with netowrking
	/// </summary>
	public static class VacuumFactory {


		/// <summary>
		/// Creates a vacuum in the scene and let's the GameManager know of it's existance
		/// </summary>
		/// <returns>The vacuum.</returns>
		/// <param name="position">Position.</param>
		public static GameObject createVacuum(Vector3 position){

			GameObject vacuum = (GameObject)GameObject.Instantiate (Resources.Load<GameObject>("Character/Vacuum"), position, Quaternion.identity);

			GameManager.getInstance ().addCharacterToGame (vacuum.GetComponent<VacuumBehavior>());

			return vacuum;

		}

	}

}