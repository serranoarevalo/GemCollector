using UnityEngine;
using System.Collections;

public class Claw : MonoBehaviour {

	public Transform Origin = null;
	public float Speed = 4f;
	public Turret TurretScript = null;

	public int GemValue = 100;

	private Vector3 target;
	private GameObject childObject = null;
	private LineRenderer lineRenderer;

	private bool isGemHit = false;
	private bool isRetracting = false;

	void Awake() {
		lineRenderer = GetComponent<LineRenderer> ();
	}

	void Update() {
		float step = Speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards (transform.position, target, step);
		lineRenderer.SetPosition (0, Origin.position);
		lineRenderer.SetPosition(1, transform.position);

		if (transform.position == Origin.position && isRetracting && TurretScript != null) {
			TurretScript.CollectedObject ();

			if (isGemHit) {

				isGemHit = false;
			}

			if (childObject != null) {
				Destroy (childObject);
			}

			gameObject.SetActive(false);
			isRetracting = false;
		}
	}

	public void ClawTarget (Vector3 targetPos) {
		target = targetPos;
	}

	void OnTriggerEnter(Collider other) {
		if (!isRetracting) {
			isRetracting = true;
			target = Origin.position;

			if (other.gameObject.CompareTag("Gem")) {
				isGemHit = true;
			}

			if (!other.gameObject.CompareTag ("Barrier")) {
				childObject = other.gameObject;
				childObject.transform.SetParent (this.transform);
			}
		}
	}
}
