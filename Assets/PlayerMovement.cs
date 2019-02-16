using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class PlayerMovement : MonoBehaviour {
	public float speed = 10.0f;
	public float gravity = -9.8f;

	private CharacterController _charController;
	private float timer = 0.0f;

	public bool victory = false;

	[SerializeField] private TextMesh gameOverText;
	[SerializeField] private TextMesh InstructionText;
	[SerializeField] private TextMesh trapText;

	
	void Start() {
		_charController = GetComponent<CharacterController>();
	}
	
	void Update() {
		timer += Time.deltaTime;
		if (timer >= 20.0f)
			InstructionText.text = "";

		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
		Vector3 pos = transform.position;
		if (pos.x <= -47 && pos.z <= 1)
		{
			victory = true;
			gameOverText.text = "You have found my power source \n Good job! Now turn around";
			trapText.text = "People who dare to step into MD maze shall be punished\n You are trapped here forever with your immortality. Muahahaha";
			Debug.Log("victory");
		}


	}
}
