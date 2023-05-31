using UnityEngine;

public class ColorCycle : MonoBehaviour
{
    public float cycleSpeed = 1.0f; // Adjustable speed of color cycle
    public Color[] colors; // Array of colors to cycle through

    private int currentIndex = 0;
    private Light spotlight;
    private float colorTimer = 0.0f;
    private float fadeTime = 1.0f;

    private void Start()
    {
        spotlight = GetComponent<Light>();
        spotlight.color = colors[currentIndex];
    }

    private void Update()
    {
        colorTimer += Time.deltaTime;

        // Check if it's time to transition to the next color
        if (colorTimer >= fadeTime)
        {
            // Increment the index and loop back to 0 if necessary
            currentIndex = (currentIndex + 1) % colors.Length;
            colorTimer = 0.0f;
        }

        // Get the current and next colors
        Color currentColor = colors[currentIndex];
        Color nextColor = colors[(currentIndex + 1) % colors.Length];

        // Calculate the lerp factor based on the timer and fade time
        float lerpFactor = Mathf.Clamp01(colorTimer / fadeTime);

        // Smoothly transition between colors
        Color lerpedColor = Color.Lerp(currentColor, nextColor, lerpFactor);
        spotlight.color = lerpedColor;
    }
}
