using UnityEngine;
using System.Collections;


namespace VGDC.Character {


	/// <summary>
	/// These are the guts of how the vacuum will behave in the scene,
	/// Other components such as VacuumPlayerControlBehavior or 
	/// VacuumAIControlBehavior call these functions to control the Vacuum
	/// </summary>
	public class VacuumBehavior : CharacterBehavior {


		/// <summary>
		/// The charge of the vacuum
		/// </summary>
		private float charge;


		public void boost(){

		}


		public void eatBattery(GameObject battery){
			GameManagement.GameManager.getInstance ().notifyVacuumBatteryConsumption (this);
			Destroy (battery);
		}


		public float getCharge(){
			return charge;
		}


		public void setCharge(float newCharge){
			charge = Mathf.Clamp01 (newCharge);
		}


	}


}