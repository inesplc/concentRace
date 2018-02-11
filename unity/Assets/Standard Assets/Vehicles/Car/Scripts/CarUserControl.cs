using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{

    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
		private CarController m_Car; // the car controller we want to use
		public float concent;
		public int choice;
		public bool Muse = false;

		public MuseVariable UsingMuse;

		public RotatableGuiItem velNeedle;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();

			Muse = UsingMuse.UseMuse;
			if (Muse == true) {
				choice = 1;
				Debug.Log ("Choice is Yes");
			} else {
				choice = 0;
				Debug.Log ("Choice is No");
			}
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

			m_Car.Move(h, v*Convert.ToInt16(!Muse) + concent*choice, v, 0f);

			var mph = - m_Car.CurrentSpeed;
			velNeedle.angle = 270 - mph*3f;
		}
	}
}
