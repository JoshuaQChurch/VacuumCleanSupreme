using UnityEngine;
using System.Collections;
using VGDC.Character;

namespace VGDC.GameManagement {

	public interface GameMode {

		void onGameStart();

		void onCharacterDeath(CharacterBehavior character);

		void onCharacterAdd(CharacterBehavior character);

	}

}