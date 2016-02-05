using UnityEngine;
using UnityEngine.UI;

namespace VGDC.Notification {


	/// <summary>
	/// Notification system, to ease instantiation of notifications on the players
	/// screen and across networks
	/// </summary>
	public static class NotificationSystem  {


		/// <summary>
		/// Creates a notification and displays it for the amount of time alotted
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="message">Message.</param>
		/// <param name="duration">Duration.</param>
		public static void createNotification(string title, string message, float duration){

			GameObject notificationRef = (GameObject)Resources.Load ("Notification/Notification");

			GameObject notification = (GameObject)GameObject.Instantiate (notificationRef, Vector3.zero, Quaternion.identity);

			notification.transform.FindChild("Panel").transform.FindChild("Body Text").GetComponentInChildren<Text> ().text = message;
			notification.transform.FindChild("Panel").transform.FindChild("Header").GetComponentInChildren<Text> ().text = title;

			Object.Destroy (notification, duration);

		}


		/// <summary>
		/// Creates a notification and displays it for the amount of time alotted.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="duration">Duration.</param>
		public static void createNotification(string message, float duration){

			GameObject notificationRef = (GameObject)Resources.Load ("Notification/Notification");

			GameObject notification = (GameObject)GameObject.Instantiate (notificationRef, Vector3.zero, Quaternion.identity);

			notification.transform.FindChild("Panel").transform.FindChild("Body Text").GetComponentInChildren<Text> ().text = message;

			Object.Destroy (notification, duration);

		}


	}

}