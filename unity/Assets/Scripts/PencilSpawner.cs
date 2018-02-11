using UnityEngine;
using System.Collections;

public class PencilSpawner : MonoBehaviour {

	private GameObject[] gos;
	public GameObject objectToSpawn;
	ArrayList arrayList = new ArrayList();
	private Vector3 position;
	private float posX, posZ;
	private float tempX, tempZ;


	void  Start (){

		gos = GameObject.FindGameObjectsWithTag("Road"); 

//		if (gos != null) {
//			Debug.Log("found roads");
//		}

		int count = 0;

		foreach (GameObject go in gos){
			arrayList.Add(go.transform.position);
			count += 1;
		}

//		Debug.Log(count);

		//first spawn
		int x = Random.Range(0,count-1);
		
		position = (Vector3)arrayList[x];

		posX = position.x; posZ = position.z;
		tempX = posX; tempZ = posZ;
		
		objectToSpawn = Instantiate (objectToSpawn, new Vector3(posX,1.8f,posZ) , Quaternion.identity) as GameObject;
		objectToSpawn.SetActive(true);


		for(int i = 1; i <= 9; i++){

			x = Random.Range(0,count-1);

			position = (Vector3)arrayList[x];
			//Debug.Log(position);
			
			posX = position.x;
			posZ = position.z;

			while ( Mathf.Sqrt( Mathf.Pow((posX-tempX),2) + Mathf.Pow((posZ-tempZ),2) ) < 70f){
				x = Random.Range(0,count-1);
				position = (Vector3)arrayList[x];
				posX = position.x;
				posZ = position.z;
			}

			tempX = posX; tempZ = posZ;
			objectToSpawn = Instantiate (objectToSpawn, new Vector3(posX,1.8f,posZ) , Quaternion.identity) as GameObject;
			objectToSpawn.SetActive(true);
		}
	}
	
}