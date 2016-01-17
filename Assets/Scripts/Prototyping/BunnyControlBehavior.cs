using UnityEngine;
using System.Collections;

namespace VGDC.Prototyping {

	public class BunnyControlBehavior : PlayerControlBehavior {

		float lastTimeTrapLayed = -1000;
		float speedOfTrapPlacement = 5f;

		protected override void childStart ()
		{
			player.setSpeed(player.getSpeed()*.9f);
		}

		protected override void childUpdate ()
		{
			
			if (Input.GetKey (KeyCode.Space) && canPlaceTrap() ) {

				Vector3 posOfTrap = transform.position;
				posOfTrap.y -= .015f + .072f;

				PhotonNetwork.Instantiate ("Prototyping/Trap", posOfTrap, Quaternion.identity,0);
				lastTimeTrapLayed = Time.time;

			}

		}

		private bool canPlaceTrap(){
			return Time.time - lastTimeTrapLayed > speedOfTrapPlacement;
		}

	}

}