using UnityEngine;
using System.Collections;
using Photon;
using VGDC.Notification;

namespace VGDC.Prototyping {

	public class RandomMatchmaker : Photon.PunBehaviour {

		public Camera overviewCamera;

		// Use this for initialization
		void Start()
		{
			PhotonNetwork.ConnectUsingSettings("0.1");
			PhotonNetwork.autoJoinLobby = true;
			//PhotonNetwork.logLevel = PhotonLogLevel.Full;
		}

		void OnGUI()
		{
			GUI.Label(new Rect(5,Screen.height-20,200,20), PhotonNetwork.connectionStateDetailed.ToString());

			if(PhotonNetwork.connectionStateDetailed == PeerState.Joined && playerIsDead()){

				overviewCamera.enabled = true;

				if (GUI.Button (new Rect(Screen.width/2 -75, Screen.height/2 -20, 150,30), "Spawn as Vacuum")) {
					spawnAs ("Vacuum");
				}

				if (GUI.Button (new Rect(Screen.width/2 -75, Screen.height/2 +20, 150,30), "Spawn as Bunny")) {
					spawnAs ("Bunny");
				}


				GUI.Box(new Rect(Screen.width/2 -75, Screen.height/2 -100, 150,50),"Enter Your Name");
				PhotonNetwork.playerName = GUI.TextField(new Rect(Screen.width/2 -65, Screen.height/2 -80, 130,25),PhotonNetwork.playerName);

				GUI.Box(new Rect(Screen.width/2+80,Screen.height/2 -20,150, 20 + (PhotonNetwork.playerList.Length*30)),"Players");

				for(int i = 0; i < PhotonNetwork.playerList.Length; i ++){

					GUI.Button(new Rect(Screen.width/2+90,Screen.height/2 + (i*30),130, 20),PhotonNetwork.playerList[i].name);
						
				}

			}
		}

		public override void OnJoinedLobby()
		{
			PhotonNetwork.JoinRandomRoom();
		}

		void OnPhotonRandomJoinFailed()
		{
			Debug.Log("Can't join random room!");
			PhotonNetwork.CreateRoom(null);
		}
		

		void spawnAs(string toSpawnAs) {

			GameObject monster = PhotonNetwork.Instantiate("Prototyping/"+toSpawnAs, Vector3.up*10, Quaternion.identity, 0);
			PlayerControlBehavior controller = monster.GetComponent<PlayerControlBehavior>();
			controller.enabled = true;

			PlayerBehavior player = monster.GetComponent<PlayerBehavior> ();
			player.enabled = true;
			monster.GetPhotonView ().RPC ("setName",PhotonTargets.AllBuffered, new object[]{PhotonNetwork.playerName});

			monster.GetComponentInChildren<Camera>().enabled = true;
			monster.GetComponentInChildren<AudioListener> ().enabled = true;

			overviewCamera.enabled = false;

		}

		bool playerIsDead(){

			PlayerBehavior[] players = GameObject.FindObjectsOfType<PlayerBehavior> ();

			for (int i = 0; i < players.Length; i++) {
				if (players [i].enabled == true) {
					return false;
				}
			}

			return true;

		}

	}

}