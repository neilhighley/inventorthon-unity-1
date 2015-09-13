using UnityEngine;
using System.Collections;

public class DisplayTextForAlert : MonoBehaviour {

    private UnityEngine.UI.Text displayText;

    // Use this for initialization
    void Start()
    {
        displayText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update () {
        if (!string.IsNullOrEmpty(globalVars.AlertText))
        {
            displayText.text = globalVars.AlertText;
        }
    }
}
