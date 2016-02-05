using UnityEngine;
using System.Collections;
using VGDC.FX;

namespace VGDC.Notification {

	public class NotificationTest : MonoBehaviour {

		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyUp (KeyCode.A)) {
				SpecialEffectsFactory.createEffect (Vector3.up, SpecialEffectType.BunnyDeath);
				NotificationSystem.createNotification ("Hey!", "Whatsup brahhhhhh", 5f);

			}
		}
	}

}