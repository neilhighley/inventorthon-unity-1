using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonBehaviour : MonoBehaviour {

    public Slider slider;

    public void DoSomething()
    {
        Debug.Log(slider.value);
    }

    public void DoSomethingWithASlider(Slider slider2)
    {
        Debug.Log(slider2.value);
    }
}
