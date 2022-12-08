using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SquareManager : MonoBehaviour
{
    private Square mySquare;

    public Slider heightSlider;
    public Slider widthSlider;

    public GameObject heightTextObject;
    public GameObject widthTextObject;
    public GameObject perimeterTextObject;
    public GameObject areaTextObject;

    private TextMeshProUGUI heightText { get; set; }
    private TextMeshProUGUI widthText { get; set; }
    private TextMeshProUGUI perimeterText { get; set; }
    private TextMeshProUGUI areaText { get; set; }

    void Start()
    {
        heightText = heightTextObject.GetComponent<TextMeshProUGUI>();
        widthText = widthTextObject.GetComponent<TextMeshProUGUI>();
        perimeterText = perimeterTextObject.GetComponent<TextMeshProUGUI>();
        areaText = areaTextObject.GetComponent<TextMeshProUGUI>();

        mySquare = new Square();

        GetValuesFromSliders();
    }

    void Update()
    {
        heightText.text = "Square Height: " + mySquare.GetHeight().ToString();
        widthText.text = "Square Width: " + mySquare.GetWidth().ToString();
        perimeterText.text = "Square Perimeter: " + mySquare.GetPerimeter().ToString();
        areaText.text = "Square Area: " + mySquare.GetArea().ToString();
    }

    public void SliderChanged(float newValue)
    {
        GetValuesFromSliders();
    }

    private void GetValuesFromSliders()
    {
        mySquare.SetHeight(heightSlider.value);
        mySquare.SetWidth(widthSlider.value);
    }
}