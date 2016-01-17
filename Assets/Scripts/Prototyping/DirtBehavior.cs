using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VGDC.Prototyping {

	public class DirtBehavior : MonoBehaviour {

		private float secondsRequiredToEat = 10f;

		private List<PlayerBehavior> players = null; 

		private List<float> playersTimesOnSpot = null;

		void Start(){
			players = new List<PlayerBehavior> ();
			playersTimesOnSpot = new List<float> ();
		}

		public void eat(PlayerBehavior player){
		
			if (players.Contains (player)) {

				int index = players.IndexOf (player);
				playersTimesOnSpot [index] += Time.deltaTime;

				if(playersTimesOnSpot[index] >= secondsRequiredToEat){
					Destroy (gameObject);
				}

			} else {
				players.Add (player);
				playersTimesOnSpot.Add (0f);
			}
		
		}


		public float getPercentageLeftToEat(PlayerBehavior player){

			if(players.Contains (player)) {
				
				return playersTimesOnSpot [players.IndexOf (player)] / secondsRequiredToEat;

			}

			return 1f;

		}


	}

}