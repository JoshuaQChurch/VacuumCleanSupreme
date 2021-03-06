//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using Photon;

namespace VGDC.Prototyping {
	public class BatterySpawnBehavior : Photon.MonoBehaviour {
		//cooldown for battery spawns
		private float batterySpawnInterval = 10f;

		//set custom range for random position
		private float MinX = -27.5f;
		private float MaxX = 27.5f;
		private float MinY = 0.2f;
		private float MaxY = 0.2f;
		
		//for 3d you have z position
		private float MinZ = -23.5f;
		private float MaxZ = 23.5f;
		
		//turn off or on 3D placement
		private bool is3D = true;

		//battery cooldown
		private float batteryCooldown;

		void Start() {
			batteryCooldown = batterySpawnInterval;
		}

		void Update() {
			if (PhotonNetwork.isMasterClient) {
				batteryCooldown = Mathf.Clamp (batteryCooldown - Time.deltaTime, 0, 1000);

				if (batteryCooldown <= 0) {
					batteryCooldown = batterySpawnInterval;
					SpawnBattery ();
				}
			}

		}
		
		public void SpawnBattery() {
			float x = Random.Range(MinX,MaxX);
			float y = Random.Range(MinY,MaxY);
			float z = Random.Range(MinZ,MaxZ);
			
			if(is3D) {
				PhotonNetwork.Instantiate("Prototyping/Battery", new Vector3(x,y,z), Quaternion.identity, 0);
			}
			else {
				PhotonNetwork.Instantiate("Prototyping/Battery", new Vector3(x,y,0), Quaternion.identity, 0);
			}
		}
	}
}

