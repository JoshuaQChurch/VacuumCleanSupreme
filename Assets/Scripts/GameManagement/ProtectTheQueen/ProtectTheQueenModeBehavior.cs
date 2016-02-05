using UnityEngine;
using System.Collections;
using VGDC.GameManagement;
using VGDC.Character;
using VGDC.Notification;

namespace VGDC.GameManagement.ProtectTheQueen {


	/// <summary>
	/// In the game mode *Protect the queen*, one of the 3 bunnies is assigned the status *Queen*.  
	/// The queen can not place traps, but the other 2 bunnies can with the traps having a 10 second lifespwn.  
	/// If the round ends and the queen is still alive, the bunnies won.  
	/// The Vacuum wins if it consumes the queen before the time limit.  
	/// </summary>
	public class ProtectTheQueenModeBehavior :  GameMode {

		/// <summary>
		/// The time in the game when we last spawned the battery.
		/// </summary>
		private float lastBatterySpawnTime = 0f;

		/// <summary>
		/// The time in the game the round started.
		/// </summary>
		private float timeRoundStarted = 0f;

		/// <summary>
		/// The time limit for each round.
		/// The time the queen has to survive to win
		/// </summary>
		private float timeForEachRoundInSeconds = 60f;

		/// <summary>
		/// The number of rounds per game
		/// </summary>
		private float numberOfRounds = 3;

		/// <summary>
		/// The current round we're playing
		/// </summary>
		private float currentRound = 0;

		/// <summary>
		/// The character that is considered the bunny queen
		/// </summary>
		private CharacterBehavior bunnyQueen = null;

		/// <summary>
		/// The rounds the bunnies have won.
		/// </summary>
		private int roundsBunniesHaveWon = 0;

		/// <summary>
		/// The rounds the vacuum has won.
		/// </summary>
		private int roundsVacuumHaveWon = 0;

		/// <summary>
		/// The state of the current game.
		/// </summary>
		private GameState currentGameState = GameState.StartOfRound;


		/// <summary>
		/// Initializes the round
		/// </summary>
		public override void onGameStart(){

			currentRound ++;

			// Initialize timing variables
			lastBatterySpawnTime = Time.time;
			timeRoundStarted = Time.time;

			//TODO Spawn all characters at appropriate places, bunnies clustered together and away from the vacuum

			//TODO Select a random bunny to be queen

		}


		/// <summary>
		/// When a bunny dies
		/// </summary>
		/// <param name="character">Character.</param>
		public override void onCharacterDeath(CharacterBehavior character){

			// If the queen was killed
			if (bunnyQueen.Equals (character)) {

				roundsVacuumHaveWon ++;
				goToEndOfRound();

			} else {

				spawnBattery();

				// TODO spawn the player back in 10 seconds

				// TODO slow the vacuum for 5 seconds
			}

		}


		/// <summary>
		/// Play a cool effect when a character is spawned
		/// </summary>
		/// <param name="character">Character.</param>
		public override void onCharacterAdd(CharacterBehavior character){
			//TODO play a cool effect when a character is spawned
			NotificationSystem.createNotification("A player has spawned!",2f);
		}


		/// <summary>
		/// The vacuum gains back only a quater of it's charge when it consumes a battery
		/// </summary>
		/// <param name="vacuum">Vacuum.</param>
		public override void onVacuumBatteryConsumption (VacuumBehavior vacuum)
		{
			vacuum.setCharge (vacuum.getCharge() +.25f);
		}


		// Update is called once per frame
		void Update () {
		
			batterySpawnUpdate ();
			gameStateUpdate ();

		}


		/// <summary>
		/// Update function to monitor the current game state
		/// </summary>
		private void gameStateUpdate(){

			switch (currentGameState) {
			
			case GameState.BeingPlayed:

				if(getTimeLeftInRound() <= 0){

					goToEndOfRound();

					// Queen has survived to end of round
					roundsBunniesHaveWon ++;

				}

				break;
			
			}

		}


		/// <summary>
		/// Ends the current round and sets up for next round if appropriate
		/// </summary>
		private void goToEndOfRound(){

			GameManager.getInstance().clearCharactersInScene();

			if (currentRound >= numberOfRounds) {

				currentGameState = GameState.EndOfGame;

				// TODO Start next round in 15 seconds if theirs still rounds to go
				
			} else {

				currentGameState = GameState.EndOfRound;
			
				// TODO Go back to Network room in 15 seconds

				// TODO save match results to player's local machine

			}

			// TODO pull up round/game result UI for each player


		}


		/// <summary>
		/// Update for monitoring when a battery should spawn.
		/// </summary>
		private void batterySpawnUpdate(){

			// If it's time to spawn another battery
			if(Time.time - lastBatterySpawnTime > 15f){

				lastBatterySpawnTime = Time.time;

				// If we have 15 seconds left in the match
				if( getTimeLeftInRound() < 16f){ // 16 because I'm not sure if it'll catch if I do 15 due to floating point math
					spawnBattery();
					spawnBattery();
					spawnBattery();
				} else {
					spawnBattery();
				}

			}

		}


		/// <summary>
		/// Spawns a battery randomly in the scene
		/// </summary>
		private void spawnBattery(){
			Consumables.ConsumableFactory.createConsumable (VGDC.Consumables.ConsumableType.Battery, Vector3.zero);
		}


		/// <summary>
		/// Returns the time left for the current round being played
		/// </summary>
		/// <returns>The time left in round.</returns>
		private float getTimeLeftInRound(){
			return Mathf.Clamp (timeForEachRoundInSeconds - (Time.time - timeRoundStarted), 0, timeForEachRoundInSeconds);
		}


	}


}