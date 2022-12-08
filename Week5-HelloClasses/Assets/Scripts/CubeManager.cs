using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    private Cube myCube;
    public Slider lengthSlider;
    public Slider heightSlider;
    public Slider widthSlider;
    public GameObject heightTextObject;
    public GameObject edgeTextObject;
    public GameObject widthTextObject;
    public GameObject lengthTextObject;
    public GameObject volumeTextObject;
    

    
    private TextMeshProUGUI widthText { get; set; }
    private TextMeshProUGUI lengthText { get; set; }
    private TextMeshProUGUI volumeText { get; set; }
    private TextMeshProUGUI edgeText { get; set; }
    private TextMeshProUGUI heightText { get; set; }
    void Start()
    {
        heightText = heightTextObject.GetComponent<TextMeshProUGUI>();
        widthText = widthTextObject.GetComponent<TextMeshProUGUI>();
        lengthText = lengthTextObject.GetComponent<TextMeshProUGUI>();
        volumeText = volumeTextObject.GetComponent<TextMeshProUGUI>();
        edgeText = edgeTextObject.GetComponent<TextMeshProUGUI>();

        myCube = new Cube();

        GetSliderValue();
    }

  

    private void GetSliderValue()
    
    {
        myCube.setHeight(heightSlider.value);
        myCube.setWidth(widthSlider.value);
        myCube.setLength(lengthSlider.value);
    }
    void Update()
    {
        heightText.text = "Height: " + myCube.getHeight().ToString();
        widthText.text = "Width: " + myCube.getWidth().ToString();
        lengthText.text = "Length: " + myCube.getLength().ToString();
        volumeText.text = "Volume: " + myCube.getVolume().ToString();
        edgeText.text = "Edge Length: " + myCube.getEdge().ToString();
    

}
    public void SliderChanged(float newValue)
    {
        GetSliderValue();
    }
    
}