using UnityEngine;
using System.Collections;
using VGDC.Character;

namespace VGDC.Character.Controller {

	/// <summary>
	/// abstract character control behavior for defining basic controller behavior
	/// that's shared across multiple characters
	/// </summary>
	public abstract class CharacterControlBehavior : MonoBehaviour {

		private CharacterBehavior characterControlling;

		// Use this for initialization
		void Start () {

			controlerStart ();

			characterControlling = gameObject.GetComponent<CharacterBehavior> ();
		
		}


		// Update is called once per frame
		void Update () {
		
			controlerUpdate ();

			if (characterControlling == null) {
				Debug.LogWarning ("Trying to control an object that has no character behavior attatched!");
				return;
			}

			float horz = Input.GetAxis ("Horizontal");

			if(horz != 0){

				if (horz > 0) {
					characterControlling.moveRight (horz);
				} else {
					characterControlling.moveLeft (horz);
				}

			}

			float vert = Input.GetAxis ("Vertical");

			if(vert != 0){

				if (vert > 0) {
					characterControlling.moveRight (vert);
				} else {
					characterControlling.moveLeft (vert);
				}

			}

		}


		/// <summary>
		/// Made to allow child classes to have their own start function without
		/// overwriting the base class's Start()
		/// </summary>
		protected abstract void controlerStart();


		/// <summary>
		/// Made to allow child classes to have their own update function without
		/// overwriting the base class's Update()
		/// </summary>
		protected abstract void controlerUpdate();

	}

}