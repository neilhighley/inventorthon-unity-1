using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

    public GameObject panelInfow;
    public GameObject panelTime;
    public GameObject panelPerson;
    public GameObject panelCompass;
    public string someText;

    public GameObject cubeToUse;

    private GameObject[] cubes=new GameObject[200];

    // Use this for initialization
    void Start () {
        //turn off all panels
        panelPerson.SetActive(false);
        panelTime.SetActive(false);
        panelPerson.SetActive(false);
        panelCompass.SetActive(false);
        AddCubes();
	}
	
    void AddCubes()
    {
        var xMax = 500;
        var zMax = 500;
        var num = 20;
        //create a new object
        var r = new System.Random();                
        for(var i=0;i< num; i++)
        {
            //, Quaternion.identity
            //Instantiate(cubeToUse, new Vector3(r.Next(100, xMax)+2000, 3100, r.Next(100, zMax)+2000), Quaternion.identity);
            //place it at random co-ords
            //Debug.Log("Cube Created at:" + tinstance.transform.position.x + "," + tinstance.transform.position.y + "," + tinstance.transform.position.z);
            //cubes[i] = tinstance; 
        }
        
    }

	// Update is called once per frame
	void Update () {
	
	}
}
