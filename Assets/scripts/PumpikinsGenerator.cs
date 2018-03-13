using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpikinsGenerator : MonoBehaviour {

	public float limitLeft, limitRight, limitFront, limitBack;
	public float speed;
	public GameObject pumpikin;

	IEnumerator Start () {
		yield return new WaitForSeconds (Random.Range (0.5f, speed));

		Vector3 position;
		position.x = Random.Range (limitLeft, limitRight);
		position.z = Random.Range (limitFront, limitBack);
		position.y = transform.position.y;

		Instantiate (pumpikin, position, transform.rotation);
		StartCoroutine (Start ());
	}
}
