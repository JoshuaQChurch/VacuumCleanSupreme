using UnityEngine;
using System.Collections;

namespace VGDC.Prototyping {

	public class BunnyControlBehavior : PlayerControlBehavior {

		float lastTimeTrapLayed = -1000;
		float speedOfTrapPlacement = 5f;
		float trapCooldownTime = 0f;

		protected override void childStart ()
		{
			player.setSpeed(player.getSpeed()*.9f);
		}

		protected override void childUpdate ()
		{
			trapCooldownTime = Mathf.Clamp (trapCooldownTime - Time.deltaTime, 0, 1000);
			
			if (Input.GetKey (KeyCode.Space) && canPlaceTrap() ) {

				trapCooldownTime = 5f;

				Vector3 posOfTrap = transform.position;
				posOfTrap.y -= .015f + .072f;

				PhotonNetwork.Instantiate ("Prototyping/Trap", posOfTrap, Quaternion.identity,0);
				lastTimeTrapLayed = Time.time;

			}

		}

		private bool canPlaceTrap(){
			return trapCooldownTime <= 0;
			// return Time.time - lastTimeTrapLayed > speedOfTrapPlacement;
		}

		void OnGUI(){
			if (trapCooldownTime != 0) {
				GUI.Box (new Rect(Screen.width/2-55,Screen.height-40,150,30), "Trap cooldown: "+trapCooldownTime.ToString("0.0")+" seconds");
			}
			
		}
	}

}