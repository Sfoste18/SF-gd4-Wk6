using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UITest : MonoBehaviour
{

    public Toggle _toggle;
    public Slider _slider;
    //public TMP_InputField _InputField;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent <AudioSource>().volume = _slider.value/10;
        GetComponent <AudioSource>().enabled = _toggle.isOn;



    }
}
