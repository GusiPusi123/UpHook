using UnityEngine;
using UnityEngine.UI;

public class RainbowText : MonoBehaviour
{
    public Text uiText; // Назначьте ваш текст в инспекторе
    public float colorChangeSpeed = 1f; // Скорость смены цветов

    private void Update()
    {
        if (uiText != null)
        {
            // Генерируем цвет по радужной гамме с помощью HSV
            float hue = Mathf.PingPong(Time.time * colorChangeSpeed, 1f);
            Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);
            uiText.color = rainbowColor;
        }
    }
}