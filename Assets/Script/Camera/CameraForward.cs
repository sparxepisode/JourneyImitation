using UnityEngine;
using System.Collections;

public class CameraForward : MonoBehaviour {

	public float m_delay;
	public float m_speed=1.0f;

	public Transform target;

	public Vector3 m_arrow;

	// Use this for initialization
	void Start () {
		StartCoroutine (IEMove ());
		m_arrow = transform.forward;

	}

	IEnumerator IEMove()
	{
		yield return new WaitForSeconds (m_delay);

		while (true) {
			if (JuageMoveStop ())
				yield break;

			transform.transform.position += m_arrow * Time.deltaTime * m_speed;
			yield return null;
		}
	}


	bool JuageMoveStop()
	{
		if (target == null)
			return false;
			 
		return Vector3.Distance (target.position, this.transform.position) < 1.0f?true:false;
	}
}
