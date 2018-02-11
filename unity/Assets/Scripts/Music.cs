using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {


	public GameObject audio;
	
	// Use this for initialization
	void Awake () {

		AudioListener.pause = false;

		//When the scene loads it checks if there is an object called "MUSIC".
		audio = GameObject.Find ("Music");
		//If this object does not exist then it does the following:
		if (audio == null) {
			//1. Sets the object this script is attached to as the music player
			audio = this.gameObject;
			//2. Renames THIS object to "MUSIC" for next time
			audio.name = "Music";
			//3. Tells THIS object not to die when changing scenes.
			DontDestroyOnLoad (audio);
		} else {
			if(this.gameObject.name!="Music")
				//If there WAS an object in the scene called "MUSIC" (because we have come back to
				//the scene where the music was started) then it just tells this object to 
				//destroy itself if this is not the original
				Destroy(this.gameObject);
		}
	}

}

