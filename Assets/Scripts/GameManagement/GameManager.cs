using UnityEngine;
using VGDC.Character;
using System.Collections.Generic;

namespace VGDC.GameManagement {


	/// <summary>
	/// The Game manager talks to things associated with the current game mode in order
	/// to manage the state of the game with ease.  
	/// 
	/// Calls events of the current GameMode to
	/// execute, as well as keeps up with information like who's alive in the scene.
	/// </summary>
	public class GameManager {


		/// <summary>
		/// The only instance of the game manager that will ever exist.
		/// </summary>
		private static GameManager instance = null;


		/// <summary>
		/// The current mode being played that the manager alerts of events going on in the scene
		/// </summary>
		private GameMode currentModeBeingPlayed;


		/// <summary>
		/// A list of every character alive in the scene
		/// </summary>
		private List<CharacterBehavior> charactersInScene = null;


		/// <summary>
		/// Singleton method guarantees only one instance of game manager 
		/// ever exists in the application.  Lazy loaded so it's only taking
		/// up memory once it's needed in the game, speeding up loading time.
		/// </summary>
		/// <returns>The only instance in the application</returns>
		public static GameManager getInstance(){

			if (instance == null) {
				instance = new GameManager();
			}

			return instance;

		}


		/// <summary>
		/// Sets the game mode for the manager to notify
		/// </summary>
		/// <param name="gameMode">Game mode.</param>
		public void setGameMode(GameMode gameMode){
			clearCharactersInScene ();
			this.currentModeBeingPlayed = gameMode;
		}


		/// <summary>
		/// Adds a character to the game.
		/// </summary>
		/// <param name="character">Character.</param>
		public void addCharacterToGame(CharacterBehavior character){

			// If the character their trying to add is null
			if (character == null) {
				Debug.LogError("The character your trying to add to the Game Manager is null!");
				return;
			}

			// If the character their trying to add has already been added
			if (charactersInScene.Contains (character)) {
				Debug.LogError("The character your trying is add is already listed in the Game Manager!");
				return;
			}

			charactersInScene.Add (character);

			if (currentModeBeingPlayed != null) {

				// Alert the game mode.
				currentModeBeingPlayed.onCharacterAdd (character);

			} else {
				Debug.LogWarning("You just added a character to the scene while theres no game mode running!");
			}

		}


		/// <summary>
		/// Removes the character from the game and alerta the game mode that
		/// it has died
		/// </summary>
		/// <param name="character">Character.</param>
		public void removeCharacterFromGame(CharacterBehavior character){
			
			// If the character their trying to remove is null
			if (character == null) {
				Debug.LogError("The character your trying to remove from the Game Manager is null!");
				return;
			}
			
			// If the character their trying to remove isn't here
			if (!charactersInScene.Contains (character)) {
				Debug.LogError("The character your trying to remove is not listed in the Game Manager!");
				return;
			}
			
			charactersInScene.Remove (character);
			
			if (currentModeBeingPlayed != null) {
				
				// Alert the game mode.
				currentModeBeingPlayed.onCharacterDeath (character);
				
			} else {
				Debug.LogWarning("You just removed a character from the scene while theres no game mode running!");
			}
			
		}


		/// <summary>
		/// Deletes all characters from the scene
		/// </summary>
		public void clearCharactersInScene(){


			// Destroy the gameobjects that the players control in the scene.
			for (int i = 0; i < charactersInScene.Count; i ++) {

				if(charactersInScene[i].gameObject != null){

					// TODO convert this into a network call
					Object.Destroy(charactersInScene[i].gameObject);

				}

			}

			charactersInScene.Clear ();

		}


		/// <summary>
		/// Private constructor garunteeing only the class can initialize an instance of itself
		/// </summary>
		private GameManager(){

			// Initialize all variables
			charactersInScene = new List<CharacterBehavior> ();

		}


	}

}