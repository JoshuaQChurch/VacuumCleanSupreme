using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace VGDC.Prototyping {

	public class PlayerBehavior : MonoBehaviour {

		public GameObject target = null;
		CharacterController controller;

		[SerializeField]
		float speed = 4.5f;

		[SerializeField]
		float gravity = 20.0F;
		
		float jumpCooldownTime = 1f;

		private bool isBunny = false;


		// Use this for initialization
		void Start () {

			controller = GetComponent<CharacterController> ();

			// Determine if this is a bunny
			if ( GetComponent<BunnyControlBehavior> () ) {
				isBunny = true;
			}

		}

		// Update is called once per frame
		void Update () {

			// Update jump cooldown
			jumpCooldownTime = Mathf.Clamp (jumpCooldownTime - Time.deltaTime, 0, 1000);

			lookAtTargetUpdate ();

			movementUpdate ();

			if (transform.position.y < -100f) {
				Destroy (gameObject);
			}

			if(Input.GetKeyDown(KeyCode.P)){
				PhotonNetwork.Destroy (gameObject);
			}

		}

		[PunRPC]
		public void die(){
			PhotonNetwork.Destroy (gameObject );
		}

		[PunRPC]
		public void setName(string name){
			gameObject.GetComponentInChildren<Text> ().text = name;
		}
			

		public float getSpeed(){
			return speed;
		}

		public void setSpeed(float speed){
			this.speed = speed;
		}
			

		/// <summary>
		/// Update of the player movement of anything outside of external control.
		/// This includes things like gravity.
		/// </summary>
		void movementUpdate(){

			//simulate gravity
			Vector3 moveDown = Vector3.zero;
			movementDirection.y -= gravity * Time.deltaTime;
			moveDown.y = movementDirection.y;
			controller.Move (moveDown*Time.deltaTime);

			// Weaken gravity if we're standing still
			if (controller.isGrounded) {
				movementDirection.y = 0;
			}

			// Jump
			if (Input.GetKey (KeyCode.Space) && canJump() ) {
				movementDirection.y = 5;
				jumpCooldownTime = 1f;
			}

		}
		

			
		void rotateLeft(){
			transform.Rotate(Vector3.up * Input.GetAxis("Mouse X"), Space.World);

			// Maintain Z-axis rotation at zero.
			Quaternion chickenRotation = transform.rotation;
			chickenRotation.z = 0;
			transform.rotation = chickenRotation;
		}

		void rotateRight(float intensity){
			transform.Rotate(Vector3.up * Input.GetAxis("Mouse X"), Space.World);

			// Maintain Z-axis rotation at zero.
			Quaternion chickenRotation = transform.rotation;
			chickenRotation.z = 0;
			transform.rotation = chickenRotation;
		}
			

		/// <summary>
		/// Makes sure the player is always looking at the target if there is one.
		/// </summary>
		void lookAtTargetUpdate () {

			//If we don't have a target we can't look at it
			if (target == null) {
				return;
			}

			//A smooth rotation
			transform.rotation  = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), Time.deltaTime*10);
		}

		/// <summary>
		/// Moves the chicken counter clockwise around it's target if it has one
		/// </summary>
		public void strafeRight ()
		{
			if (!canMove ()) {
				return;
			}
			move(Vector3.right, speed);
		}

		/// <summary>
		/// Moves the chicken clockwise around it's target if it has one
		/// </summary>
		public void strafeLeft ()
		{
			if (!canMove ()) {
				return;
			}
			move(Vector3.left, speed);
		}

		/// <summary>
		/// Moves the chicken backwards.
		/// </summary>
		public void moveBackward()
		{
			if (!canMove ()) {
				return;
			}
			move(Vector3.back, speed);
		}

		/// <summary>
		/// Moves the chicken forward.
		/// </summary>
		public void moveForward()
		{
			if (!canMove ()) {
				return;
			}
			move(Vector3.forward, speed);
		}


		Vector3 movementDirection = Vector3.zero;

		/// <summary>
		/// Moves by the specified direction relative 
		/// to the direction the chicken is facing.
		/// 
		/// Ignores the y direction.
		/// Ignores state of chicken.
		/// </summary>
		/// <param name="direction">Direction.</param>
		void move(Vector3 direction, float movementSpeed){

			//Change the direction to be relative to the direction the chicken is facing
			//i.e. Vector3.left is chickens left instead of global left
			direction = transform.TransformDirection(direction);

			//move along x and z appropriately
			movementDirection.z = direction.z * movementSpeed;
			movementDirection.x = direction.x * movementSpeed;

			//Move chicken
			controller.Move(movementDirection * Time.deltaTime);

		}

		/// <summary>
		/// Determines whether or not the chicken is allowed to move.
		/// </summary>
		/// <returns><c>true</c>, if can move, <c>false</c> otherwise.</returns>
		bool canMove (){

			return true;

			// DEBUG
			if (controller.isGrounded) {
				return true;
			}

			return false;

		}
		
		// Define capability of jump in a bool state
		private bool canJump(){
			if (isBunny) {
				return jumpCooldownTime <= 0;
			} else {
				return false;
			}
		}

		float percentageOfDirtEaten = -1f;

		void OnTriggerStay(Collider other) {

			Debug.Log ("Eating");

			DirtBehavior dirt = other.gameObject.GetComponent<DirtBehavior> ();

			if (dirt != null) {

				dirt.eat (this);
				percentageOfDirtEaten = dirt.getPercentageLeftToEat (this);

				if (percentageOfDirtEaten >= 1f) {
					percentageOfDirtEaten = -1f;
				}

			} else {
				percentageOfDirtEaten = -1f;
			}

		}

		void OnGUI(){

			if(percentageOfDirtEaten != -1f){
				GUI.Box (new Rect(Screen.width/2-50,10,100,30),Mathf.Round(percentageOfDirtEaten*100)+" %");
			}
		
		}

	}

}