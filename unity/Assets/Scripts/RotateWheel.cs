using UnityEngine;
using System.Collections;

public class RotateWheel : MonoBehaviour {

	public float Speed = 1;
	public Transform iss;
	public GameObject wheel;

//	private void Start()
//	{
//		wheel = this.gameObject;
//	}
		
		// Update is called once per frame
	private void Update()
	{
		transform.localEulerAngles = new Vector3(0,0, transform.rotation.eulerAngles.z - Speed);

//		Vector3 dir = wheel.transform.position - iss.transform.position;
//		float angle = Mathf.Atan2(dir.y, dir.x) * mathf.Rad2Deg;
//		iss.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}


}
