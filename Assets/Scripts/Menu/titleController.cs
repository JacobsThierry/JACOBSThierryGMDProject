using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class titleController : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    public float GradientSpeed = 0.1f;
    private float currentGradient=0f;

    public Gradient ColorGradient;
    public Color CurrentColor;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();

    }

    // Update is called once per frame
    void Update()
    {
        currentGradient += GradientSpeed * Time.deltaTime;
        if(currentGradient > 1f) currentGradient = 0f;
        CurrentColor = ColorGradient.Evaluate(currentGradient);
        image.color = CurrentColor;
    }
}
