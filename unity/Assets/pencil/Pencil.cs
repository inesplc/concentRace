using UnityEngine;
using System.Collections;

public class Pencil : MonoBehaviour
{
	public float Speed = 1;
	
	// Update is called once per frame
	private void Update()
	{
		transform.localEulerAngles = new Vector3(0, transform.rotation.eulerAngles.y + Speed, 0);
	}
	
	private void OnTriggerEnter()
	{
		Destroy(gameObject);
		Manager.Instance.AddScore();
	}
}
