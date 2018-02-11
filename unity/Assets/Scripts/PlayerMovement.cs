using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private float _curSpeed;
    private Vector3 _forward;
    public float RotateSpeed = 3.0F;
    public float Speed = 5.0F;
    private Touch _touch;
    private float _touchpoint;
    //public float touchpoint;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _touchpoint = 0;
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            _touchpoint = (_touch.position.x - (Screen.width / 2)) / (Screen.width / 2);
        }
        transform.Rotate((Input.GetAxis("Horizontal") + _touchpoint)*RotateSpeed,0, 0);

		#if UNITY_WP8
			transform.Rotate(Input.accelaration.x * RotateSpeed), 0);
		#endif

        _forward = transform.TransformDirection(Vector3.left);
        _curSpeed = Speed;
        _controller.SimpleMove(_forward*_curSpeed);
    }

//    private void OnControllerColliderHit(ControllerColliderHit hit)
//    {
//        if (hit.gameObject.tag == "Walls")
//            Manager.Instance.GameOver();
//    }
}