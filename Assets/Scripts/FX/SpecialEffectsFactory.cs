using UnityEngine;
using System.Collections;

namespace VGDC.FX {

	/// <summary>
	/// Special effects factory meant to encapsulate creation logic
	/// </summary>
	public class SpecialEffectsFactory {

		/// <summary>
		/// Creates a special effect based on the type at a specified position
		/// </summary>
		/// <returns>The effect created in the scene</returns>
		/// <param name="position">Position of where the effect is to be created.</param>
		public static GameObject createEffect(Vector3 position, SpecialEffectType effectType){

			GameObject reference = null;

			AudioClip soundEffectReference = null;

			float lifeDuration = 3f;

			//get the correct special effect from our resources
			switch(effectType){

			case SpecialEffectType.BunnyDeath:
				
				lifeDuration = 2f;
				reference = Resources.Load("Effects/Bunny Death") as GameObject;
				soundEffectReference = Resources.Load("Effects/BunnyOww") as AudioClip;
				break;

			}

			//create the object in the scene
			GameObject effectInstance = Object.Instantiate(reference, position,Quaternion.identity) as GameObject;

			//add sound effect if there is one to add
			if(soundEffectReference != null){
				effectInstance.AddComponent<AudioSource>();
				effectInstance.GetComponent<AudioSource>().clip = soundEffectReference;
				effectInstance.GetComponent<AudioSource>().playOnAwake = false;
				effectInstance.GetComponent<AudioSource>().Play();
			}

			//Set the object to be destroyed in a certain amount of  time
			Object.Destroy (effectInstance, lifeDuration);

			return effectInstance;

		}

	}

}