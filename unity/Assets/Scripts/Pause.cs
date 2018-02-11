using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    public GUISkin skin;

//    private float gldepth = -0.5f;
    private float startTime = 0.1f;
   
    public Material mat;

    private float savedTimeScale;

    private bool _gameOver;
        
    public GameObject start;

    public Color statColor = Color.white;

    public float GammaCorrection;

    public enum Page
    {
        None, Main, Options, Menu, Quit
    }

    private Page currentPage;

    private float[] fpsarray;
    private float fps;

    private int toolbarInt = 0;
	private string[] toolbarstrings = { "Audio", "Graphics" , "Light"};

//    float rgbValue = 0.5f;  

//    void Start()
//    {
//        fpsarray = new float[Screen.width];
//        Time.timeScale = 1;
//        PauseGame();
//    }

    
   
    void LateUpdate()
    {
        if (Input.GetKeyDown("escape"))
        {
            switch (currentPage)
            {
                case Page.None:
                    PauseGame();
                    break;

                case Page.Main:
                    if (!IsBeginning())
                        UnPauseGame();
                    break;

                default:
                    currentPage = Page.Main;
                    break;
            }
        }
    }

    void OnGUI()
    {
        if (skin != null)
        {
            GUI.skin = skin;
        }
       
        if (IsGamePaused())
        {
            GUI.color = statColor;
            switch (currentPage)
            {
                case Page.Main: MainPauseMenu(); break;
                case Page.Options: ShowToolbar(); break;
//                case Page.CarSettings: ShowCarSettings(); break;
				case Page.Menu:{
					Application.LoadLevel(0); 
					AudioListener.pause = false;
					break;
					}
			case Page.Quit: Application.Quit(); break;
            }
        }
    }



    void ShowToolbar()
    {
        BeginPage(300, 300);
        toolbarInt = GUILayout.Toolbar(toolbarInt, toolbarstrings);
        switch (toolbarInt)
        {
            case 0: VolumeControl(); break;
            case 1: Qualities(); QualityControl(); break;
            case 2: LightControl(); break;
        }
        EndPage();
    }

//    void ShowCarSettings()
//    {
//        BeginPage(300, 300);
//        GUILayout.Label("Choose the color of the car:");   // colocar o color picker
//               
//
//
//
//        EndPage();
//    }

    void ShowBackButton()
    {
        if (GUI.Button(new Rect(20, Screen.height - 50, 50, 20), "Back"))
        {
            currentPage = Page.Main;
        }
    }

 
    void Qualities()
    {
        switch (QualitySettings.GetQualityLevel())
        {
            case 0:
                GUILayout.Label("Fastest");
                break;
            case 1:
                GUILayout.Label("Fast");
                break;
            case 2:
                GUILayout.Label("Simple");
                break;
            case 3:
                GUILayout.Label("Good");
                break;
            case 4:
                GUILayout.Label("Beautiful");
                break;
            default:
                GUILayout.Label("Fantastic");
                break;
        }
    }

    void QualityControl()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Decrease"))
        {
            QualitySettings.DecreaseLevel();
        }
        if (GUILayout.Button("Increase"))
        {
            QualitySettings.IncreaseLevel();
        }
        GUILayout.EndHorizontal();
    }

    void VolumeControl()
    {
        GUILayout.Label("Volume");
        AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0, 1);
    }

    void LightControl()
    {
        GUILayout.Label("Brightness");
        GammaCorrection = GUILayout.HorizontalSlider(GammaCorrection, 0, 1.0f);
        RenderSettings.ambientLight = new Color(GammaCorrection, GammaCorrection, GammaCorrection, 1.0f);

    }

    
    void BeginPage(int width, int height)
    {
        GUILayout.BeginArea(new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
    }

    void EndPage()
    {
        GUILayout.EndArea();
        if (currentPage != Page.Main)
        {
            ShowBackButton();
        }
    }

    bool IsBeginning()
    {
        return (Time.time < startTime);
    }


    void MainPauseMenu()
    {
        BeginPage(200, 200);
        if (GUILayout.Button(IsBeginning() ? "Play" : "Continue"))
        {
            UnPauseGame();

        }
        if (GUILayout.Button("Options"))
        {
            currentPage = Page.Options;
        }
     
        if (GUILayout.Button("Menu"))
        {
            currentPage = Page.Menu;
        }

        if (GUILayout.Button("Quit"))
        {
            currentPage = Page.Quit;
        }
        EndPage();
    }

 
    void PauseGame()
    {
        savedTimeScale = Time.timeScale;
        Time.timeScale = 0;
        AudioListener.pause = true;

        currentPage = Page.Main;
    }

    void UnPauseGame()
    {
        Time.timeScale = savedTimeScale;
        AudioListener.pause = false;
        currentPage = Page.None;

        if (IsBeginning() && start != null)
        {
            start.SetActive(true);
        }
    }

//    void QuitGame()
//    {
//        Application.Quit();
//    }
    

    bool IsGamePaused()
    {
        return (Time.timeScale == 0);
    }

    void OnApplicationPause(bool pause)
    {
        if (IsGamePaused())
        {
            AudioListener.pause = true;
        }
    }
}