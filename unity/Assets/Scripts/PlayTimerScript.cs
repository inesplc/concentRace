using UnityEngine;
using System.Collections;

public class PlayTimerScript : MonoBehaviour {

    private int playtime = 0;
    private int seconds = 0;
    public int minutes = 0;
	private bool _gameOver = false;
	
	void Start () {
	    StartCoroutine ( "Playtimer");
	}
	
    private IEnumerator Playtimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playtime += 1;
            seconds = (playtime % 60);
            minutes = (playtime / 60) % 60;
			Debug.Log(minutes)
		}
    }

	void Update(){
		GameOver ();
	}

	public void GameOver()
	{
		if(minutes == 1){
			_gameOver = true;
			Time.timeScale = 0;
		}
	}
	
	void OnGUI () {

		// Timer
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 20;
        myStyle.normal.textColor = Color.white;
		int sizeX = 200;
		int sizeZ = 50;

		GUI.Label(new Rect(Screen.width - sizeX, 10, sizeX, sizeZ), "Playtime: " + minutes.ToString("00") + "m:" + seconds.ToString("00") + "s", myStyle);

		//Game Over
		if (minutes == 1)
		{    
			Debug.Log("Game is over");
			if (GUI.Button(new Rect(Screen.width/2 -200, Screen.height/2 - 50, 400, 100), "You finished the race! Restart?"))
			{
				Application.LoadLevel(0);
			}
			return;
		}
    }
}
