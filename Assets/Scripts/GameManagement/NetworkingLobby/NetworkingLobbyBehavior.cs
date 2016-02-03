using UnityEngine;
using System.Collections;
using VGDC.Settings;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace VGDC.GameManagement.NetworkingLobby {

	public class NetworkingLobbyBehavior : MonoBehaviour {

		[SerializeField]
		private Image profilePic;

		[SerializeField]
		private Text onlineName;

		[SerializeField]
		private GameObject editPlayerPanel;


		/// <summary>
		/// Asynchronus so that we can load in the users profile image
		/// </summary>
		IEnumerator Start() {

			onlineName.text = OnlineSettings.getInstance ().Usename;

			// Start a download of the given URL
			WWW www = new WWW(OnlineSettings.getInstance().PicURL);

			// Wait for download to complete
			yield return www;

			// assign texture
			profilePic.sprite = Sprite.Create(www.texture, new Rect(0,0, www.texture.width, www.texture.height), Vector2.one/2f);

		}


		/// <summary>
		/// Opens the edit profile menu and set's the input fields 
		/// to what the online settings are currentely
		/// </summary>
		public void openEditMenu(){
			editPlayerPanel.SetActive (true);
			editPlayerPanel.transform.FindChild ("InputUsernameField").GetComponentInChildren<InputField>().text = OnlineSettings.getInstance ().Usename;
			editPlayerPanel.transform.FindChild ("InputPicURLField").GetComponentInChildren<InputField>().text = OnlineSettings.getInstance().PicURL;
		}


		/// <summary>
		/// Saves the edit options, and refreshes the scene so changes
		/// can be seen.
		/// </summary>
		public void saveEditOptions(){
			OnlineSettings.getInstance ().Usename = editPlayerPanel.transform.FindChild ("InputUsernameField").GetComponentInChildren<InputField> ().text;
			OnlineSettings.getInstance ().PicURL = editPlayerPanel.transform.FindChild ("InputPicURLField").GetComponentInChildren<InputField> ().text;
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}


	}

}