using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour {

	public float speed;
	public GameObject personagem;

	private Vector3 _newPosition;
	private Animation _animation;

	void Start () {
		_newPosition = transform.position;
		_animation = personagem.GetComponent<Animation> ();

		// Define animation initial of person
		_animation.CrossFade("idle");
	}

	void Update () {

		// Touch or MouseClick
		if (Input.GetButton ("Fire1")) {

			// Transform click on screen in 3D coordenates
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			// Get new position
			if (Physics.Raycast (ray, out hit)) {
				_newPosition = hit.point;
			}

			// Change animation of person when move
			_animation.CrossFade("run");

			// Look at
			transform.LookAt(hit.point);

			// Move person
			transform.position = Vector3.MoveTowards (
				transform.position, 	// start
				_newPosition, 			// end
				speed * Time.deltaTime 	// speed
			);

		} else {
			
			// Retur animation of person when break
			_animation.CrossFade("idle");
		}

		// Move person (2)
		// transform.position = Vector3.Lerp(
			// transform.position, 	// start
			// novaPosicao, 			// end
			// speed * Time.deltaTime 	// speed
		// );

		// Move person (1)
		// transform.position = novaPosicao;
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "Item") {
			Destroy (c.gameObject);
		}
	}
}
