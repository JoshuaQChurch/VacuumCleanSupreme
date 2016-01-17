﻿using UnityEngine;
using System.Collections;
using Photon;

namespace VGDC.Prototyping {

	public class RandomMatchmaker : Photon.PunBehaviour {

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

				if (GUI.Button (new Rect(Screen.width/2 -75, Screen.height/2 -20, 150,30), "Spawn as Vacuum")) {
					spawnAs ("Vacuum");
				}

				if (GUI.Button (new Rect(Screen.width/2 -75, Screen.height/2 +20, 150,30), "Spawn as Bunny")) {
					spawnAs ("Bunny");
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

		void OnJoinedRoom()
		{
			
		}

		void spawnAs(string toSpawnAs) {
			GameObject monster = PhotonNetwork.Instantiate("Prototyping/"+toSpawnAs, Vector3.up*10, Quaternion.identity, 0);
			PlayerControlBehavior controller = monster.GetComponent<PlayerControlBehavior>();
			controller.enabled = true;

			PlayerBehavior player = monster.GetComponent<PlayerBehavior> ();
			player.enabled = true;

			monster.GetComponentInChildren<Camera>().enabled = true;
			monster.GetComponentInChildren<AudioListener> ().enabled = true;
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