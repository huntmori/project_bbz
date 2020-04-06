using UnityEngine;
using System.Collections;

public class CameraTrace : MonoBehaviour 
{
	public Transform target;
	public PlayerController pc;

	public float dist = 2.0f;
	public float height = 2.0f;
	public float dampRotate = 2.0f;

	private Transform tr;
	// Use this for initialization
	void Start ()
	{
		tr = GetComponent<Transform>();
		pc = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerController> ();
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		//if (pc.isMine && pc.isCameraAttached) 
		if(true)
		{
/*
			float currYAngle = Mathf.LerpAngle (tr.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);

			Quaternion rot = Quaternion.Euler (0, currYAngle, 0);
*/
			tr.position = target.position - (/*rot */ Vector3.forward* dist) + (Vector3.up * height);
			tr.LookAt (target);
		}
	}
}
