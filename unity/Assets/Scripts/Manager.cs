using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    //public AudioClip Plim;


    private bool _gameOver;
	private bool _fall;
    private bool _paused = true;

    private int gameScore = 0;
	private float carSpeed;

	private GameObject player;
	private float car_height;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 0;
		player = GameObject.Find ("Carro");
    }

    public void AddScore()
    {
		gameScore += 1;

		if (gameScore == 10){
			GameOver();
		}
    }

	void Update()
	{
		car_height = player.transform.position.y;
		carSpeed = player.GetComponent<Rigidbody>().velocity.magnitude*3.6f;

		//Debug.Log (car_height);

		if (car_height < -10f) {
			PlayerFall();
		}
	}

	public void PlayerFall()
	{
		_fall = true;
		Time.timeScale = 0;
	}

    public void GameOver()
    {
        _gameOver = true;
        Time.timeScale = 0;

        PlayerPrefs.SetInt("CurrentScore", gameScore);
    }

    public void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 20;
        myStyle.normal.textColor = Color.white;

        if (_paused)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 20), "Start"))
            {
                Time.timeScale = 1;
                _paused = false;
            }
            return;
        }
        if (_gameOver)
        {           
            if (GUI.Button(new Rect(Screen.width/2 -200, Screen.height/2 - 50, 400, 100), "You finished the race! Restart?"))
            {
                Application.LoadLevel(0);
            }
            return;
        }
		if (_fall) 
		{
			if (GUI.Button(new Rect(Screen.width/2 -200, Screen.height/2 - 50, 400, 100), "Bad Luck! Restart?"))
			{
				Application.LoadLevel(1);
			}
			return;
		}


        GUI.Label(new Rect(10, 10, 100, 100), "Found: " + gameScore + "/10", myStyle);
		GUI.Label(new Rect(50, Screen.height - 40, 100, 100), Mathf.RoundToInt(carSpeed) + "KPH", myStyle);
    }
}