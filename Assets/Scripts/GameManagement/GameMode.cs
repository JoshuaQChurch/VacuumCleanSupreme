using UnityEngine;
using System.Collections;
using VGDC.Character;

namespace VGDC.GameManagement {

	public abstract class GameMode : MonoBehaviour {

		public abstract void onGameStart();

		public abstract void onCharacterDeath(CharacterBehavior character);

		public abstract void onCharacterAdd(CharacterBehavior character);


		/// <summary>
		/// By default when a vacuum eats a battery it will regain all it's charge
		/// </summary>
		/// <param name="vacuum">Vacuum.</param>
		public virtual void onVacuumBatteryConsumption(VacuumBehavior vacuum){
			vacuum.setCharge (1f);
		}

	}

}