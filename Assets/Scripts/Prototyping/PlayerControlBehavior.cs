using UnityEngine;
using System.Collections;

namespace VGDC.Prototyping {

	public class PlayerControlBehavior : MonoBehaviour {

		protected PlayerBehavior player;

		//The speed at which the player is rotated relative to mouse movement
		int mouseSensitivity = 5;

		// Use this for initialization
		void Start () {
			player = gameObject.GetComponent<PlayerBehavior>();
			childStart ();
            
		}

		/// <summary>
		/// Monitors input that the player will give
		/// </summary>
		void inputUpdate ()
		{
			if(Input.GetAxisRaw("Horizontal") > 0){

				player.strafeRight();

			} else if(Input.GetAxisRaw("Horizontal") < 0){


				player.strafeLeft();
			}

			if(Input.GetAxisRaw("Vertical") > 0){


				player.moveForward();

			} else if(Input.GetAxisRaw("Vertical") < 0){



				player.moveBackward();
			}


			// Rotate the chicken and camera concurrently on the X-axis with mouse movement.
			if(Input.GetAxis("Mouse X") != 0){
				transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity , Space.World);
			}

			// Rotate the camera around the chicken on Y-axis with mouse movement.
			float mouseYAxis = Input.GetAxis("Mouse Y");
            
            var yAxisPositiveRotationLimit = 0.15;
            var yAxisNegativeRotationLimit = -0.15;
            var yAxisRotationBuffer = 0.01;
            
			if(mouseYAxis != 0){

				//Debug.Log(mouseYAxis+" : "+ transform.Find("Main Camera").transform.localRotation);

				if (( mouseYAxis > 0 && transform.Find("Main Camera").transform.localRotation.x > yAxisNegativeRotationLimit ) 
					|| ( mouseYAxis < 0 && transform.Find("Main Camera").transform.rotation.x < yAxisPositiveRotationLimit ) 
				) {

					transform.Find("Main Camera").transform.RotateAround(transform.position, transform.TransformDirection(-1,0,0), mouseYAxis * mouseSensitivity);

					//					Quaternion rot = transform.Find("Main Camera").transform.localRotation;
					//					rot.x = Mathf.Clamp(transform.Find("Main Camera").transform.localRotation.x, -.15f, .2f);
					//					transform.Find("Main Camera").transform.localRotation = rot;

				} /* else if (( mouseYAxis > 0 && transform.Find("Main Camera").transform.localRotation.x > yAxisNegativeRotationLimit - yAxisRotationBuffer ) 
					|| ( mouseYAxis < 0 && transform.Find("Main Camera").transform.rotation.x < yAxisPositiveRotationLimit + yAxisRotationBuffer ) 
				) {
                    transform.Find("Main Camera").transform.RotateAround(transform.position, transform.TransformDirection(-1,0,0), mouseYAxis * mouseSensitivity * 0);
                } else {
                    transform.Find("Main Camera").transform.RotateAround(transform.position, transform.TransformDirection(-1,0,0), mouseYAxis * mouseSensitivity / 50);
                } */


			}

			 

		}

		// Update is called once per frame
		void Update () {

			inputUpdate ();

			childUpdate ();

		}

		protected virtual void childUpdate (){

		}

		protected virtual void childStart(){

		}

	}

}