using UnityEngine;
using System.Collections;

public class CompassScript : MonoBehaviour {

    public GameObject playerCam;

    //public Texture2D compTex;
    //float camAngle;

    //private float texWidth;
    //private float texHeight;

    //void Start()
    //{
    //    texWidth = 360 / Camera.main.fieldOfView * Camera.main.aspect * Screen.width;
    //    texHeight = compTex.height * texWidth / compTex.width;
    //}


    //void OnGUI()
    //{
    //    camAngle = Camera.main.transform.eulerAngles.y;

    //    if (camAngle > 180)
    //    {
    //        camAngle -= 360;
    //    }

    //    var compX = Screen.width / 2 - camAngle / 360 * texWidth;
    //    GUI.DrawTexture(new Rect(compX - texWidth, 0, texWidth, texHeight), compTex);
    //    GUI.DrawTexture(new Rect(compX, 0, texWidth, texHeight), compTex);
    //}

    // Update is called once per frame
    void Update () {
        //this.transform.rotation = playerCam.transform.rotation;
	}
}
