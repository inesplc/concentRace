using UnityEngine;
using System.Collections;

public class MuseVariable : MonoBehaviour {

	private static bool usemuse;

	public bool UseMuse { get {return usemuse;} }

	public void ChooseMuse (int buttonvalue) {
		if (buttonvalue == 1) {
			usemuse = true;
		} else if (buttonvalue == 0) {
			usemuse = false;
		}
	}
	
}
