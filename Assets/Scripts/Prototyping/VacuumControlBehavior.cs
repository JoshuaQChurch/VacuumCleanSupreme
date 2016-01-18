using UnityEngine;
using System.Collections;

namespace VGDC.Prototyping {

	public class VacuumControlBehavior : PlayerControlBehavior {

		private float charge = 1f;
		private float batteryDegrade = .16f;

		private float originalSpeed;
		private float boostMultiplier = 1.5f;

		private float remainingTrapEffectTime = 0;

		private Light statusLight;

		protected override void childStart ()
		{
			originalSpeed = player.getSpeed ();
			statusLight = transform.FindChild ("Spotlight").GetComponent<Light>();
		}

		protected override void childUpdate ()
		{

			if (charge != 0) {
				statusLight.color = new Color (1, 165f/255f, 77f/255f);
			} else {
				statusLight.color = new Color (0, 153f/255f , 152f/255f);
			}

			if (Input.GetKey (KeyCode.LeftShift) && charge > 0f && remainingTrapEffectTime == 0f) {
				player.setSpeed (originalSpeed * boostMultiplier);
				degradeCharge ();
				statusLight.color = Color.red;
			} else {
				player.setSpeed (originalSpeed);
			}

			remainingTrapEffectTime = Mathf.Clamp (remainingTrapEffectTime- Time.deltaTime, 0, 1000);
			if(remainingTrapEffectTime > 0f){
				player.setSpeed (originalSpeed*.4f);
			}

			GameObject[] bunnies = GameObject.FindGameObjectsWithTag ("Bunny");

			for (int i = 0; i < bunnies.Length; i++) {

				float diatance = Vector3.Distance (bunnies [i].transform.position, transform.position);

				if (diatance < .61) {
					
					//Destroy (bunnies [i]);
					//PhotonNetwork.Destroy (bunnies [i]);
					//PlayerBehavior bplayer = bunnies [i].GetComponent<PlayerBehavior>();
					//bplayer.enabled = true;
					//bplayer.die ();
					charge += 0.5f;
					if (charge > 1.0f) {
						charge = 1.0f;
					}

					bunnies[i].GetComponent<PhotonView> ().RPC ("die", bunnies[i].GetComponent<PhotonView>().owner, null);
				}

			}

		}

		private void degradeCharge(){
			charge = Mathf.Clamp01 (charge - Time.deltaTime * batteryDegrade);
		}


		void OnGUI(){
			
			GUI.Box (new Rect(10,10, 100,30), "Charge: "+Mathf.Round(charge*100) + " %");

			if (remainingTrapEffectTime != 0) {
				GUI.Box (new Rect(Screen.width/2-75,Screen.height-40,150,30), "Slowed for: "+remainingTrapEffectTime.ToString("0.0")+" seconds");
			}

		}

		void OnTriggerEnter(Collider other) {

			if (other.transform.tag == "Battery") {
				charge += 0.25f;
				if (charge > 1.0f) {
					charge = 1.0f;
				}
				Destroy (other.gameObject);
				PhotonNetwork.Destroy (other.gameObject);
			}

			if (other.transform.tag == "Trap") {
				remainingTrapEffectTime = 5f;
				PhotonNetwork.Destroy (other.gameObject);
			}

		}



	}

}
