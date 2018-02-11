
public var RemoteIP : String = "127.0.0.1"; //127.0.0.1 signifies a local host (if testing locally
public var SendToPort : int = 9000; //the port you will be sending from (nao e necessario pq so recebemos)
public var ListenerPort : int = 5000; //the port you will be listening on
public var controller : Transform;
public var gameReceiver = "Carro"; //the tag of the object on stage that you want to manipulate
private var handler : Osc;

var Carro : GameObject; // this is the object that contains the C# script

//VARIABLES YOU WANT TO BE ANIMATED
private var yRot : float = 0; //the rotation around the y axis
private var yFinal : float = 0;
//private var betaValue : float = 0;
//private var thetaValue : float = 1;

//VARIABLES FOR THE PROGRESS BAR
var whatChoice : int = 0;

 var barDisplay : float = 0;
 private var size : Vector2 = new Vector2(200,20);
 private var pos : Vector2 = new Vector2(Screen.width - size.x - 10 ,40);
 var progressBarEmpty : Texture2D;
 var progressBarFull : Texture2D;

public function Start ()
{
	//Initializes on start up to listen for messages
	//make sure this game object has both UDPPackIO and OSC script attached
	// NAO MEXER AQUI
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(RemoteIP, SendToPort, ListenerPort);
	handler = GetComponent("Osc");
	handler.init(udp);
	handler.SetAllMessageHandler(AllMessageHandler);

}

Debug.Log("Running");

function Update () {
	var go = GameObject.Find(gameReceiver);
	var cSharpScript = Carro.GetComponent("CarUserControl");
	
	
//	if (thetaValue > 0){
//		yRot = betaValue/thetaValue;
//	}
	
	if (yRot <= 0.30f){
		yFinal = 0f;
	} else if (yRot <= 0.7f){
		yFinal = 0.3f;
	} else {
		yFinal = 0.5f;
	}
	
	cSharpScript.concent = yFinal;
	whatChoice = cSharpScript.choice;
	
	barDisplay = yRot;
	Debug.Log('Concentraçao: ' + yRot);
	//Debug.Log('Aceleraçao: ' + yFinal);
}

//These functions are called when messages are received
//Access values via: oscMessage.Values[0], oscMessage.Values[1], etc

public function AllMessageHandler(oscMessage: OscMessage){


	var msgString = Osc.OscMessageToString(oscMessage); //the message and value combined
	var msgAddress = oscMessage.Address; //the message parameters (ex: /muse/eeg)
	var msgValue = oscMessage.Values[0]; //the message value (numeric)
//	if (msgAddress == '/muse/elements/experimental/concentration'){
//		Debug.Log(msgString);
//	}

//	//FUNCTIONS YOU WANT CALLED WHEN A SPECIFIC MESSAGE IS RECEIVED
	switch (msgAddress){
		case '/muse/elements/experimental/concentration':
			yRot = msgValue;
			//Debug.Log(msgString);
			break;
//		case '/muse/elements/beta_absolute':
//			betaValue = msgValue;
//		case '/muse/elements/theta_absolute':
//			thetaValue = msgValue;
//		default:
//			break;
	}

}

// THE PROGRESS BAR
 function OnGUI()
 {
    
   if (whatChoice == 1){
      // draw the background:
     GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
         GUI.Box (Rect (0,0, size.x, size.y),progressBarEmpty);
 
         // draw the filled-in part:
         GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
             GUI.Box (Rect (0,0, size.x, size.y),progressBarFull);
         GUI.EndGroup ();
 
     GUI.EndGroup ();
   }
 
 } 
