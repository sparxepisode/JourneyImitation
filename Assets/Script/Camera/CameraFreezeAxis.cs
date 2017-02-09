using UnityEngine;
using System.Collections;

public class CameraFreezeAxis : MonoBehaviour {

	public bool m_z;

	Vector3 euler;
	// Update is called once per frame
	void Update () {

		euler = transform.eulerAngles;

		if (m_z) {
			transform.eulerAngles = new Vector3 (euler.x, euler.y, 0);
		}
	}
}
