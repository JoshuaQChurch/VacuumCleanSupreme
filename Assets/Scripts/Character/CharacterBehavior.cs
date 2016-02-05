using UnityEngine;
using System.Collections;

namespace VGDC.Character {

	public abstract class CharacterBehavior : MonoBehaviour {


		private string characterName;


		/// <summary>
		/// When no powerups are going on, what the speed is of the character normally
		/// </summary>
		private float baseSpeed;


		/// <summary>
		/// The current speed the character is traveling
		/// </summary>
		private float currentSpeed;


		public string getName(){
			return characterName;
		}

		/// <summary>
		/// Moves the character forwards relative to it's rotation.
		/// </summary>
		/// <param name="degree">Degree.</param>
		public virtual void moveForward(float degree){
			transform.Translate (transform.InverseTransformDirection(Vector3.forward)*currentSpeed*Time.deltaTime*degree);
		}

		/// <summary>
		/// Moves the character backwards relative to it's rotation.
		/// </summary>
		/// <param name="degree">Degree.</param>
		public virtual void moveBackward(float degree){
			transform.Translate (transform.InverseTransformDirection(Vector3.back)*currentSpeed*Time.deltaTime*degree);
		}


		/// <summary>
		/// Moves the character to the left relative to it's rotation.
		/// </summary>
		/// <param name="degree">Degree.</param>
		public virtual void moveLeft(float degree){
			transform.Translate (transform.InverseTransformDirection(Vector3.left)*currentSpeed*Time.deltaTime*degree);
		}


		/// <summary>
		/// Moves the character to the right relative to it's rotation.
		/// </summary>
		/// <param name="degree">Degree.</param>
		public virtual void moveRight(float degree){
			transform.Translate (transform.InverseTransformDirection(Vector3.right)*currentSpeed*Time.deltaTime*degree);
		}


		void Start(){
			characterName = "";
			baseSpeed = 5f;
			currentSpeed = baseSpeed;
		}


	}

}