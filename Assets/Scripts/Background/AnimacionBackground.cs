using UnityEngine;

public class AnimacionBackground : MonoBehaviour
{
    public float amplitudeX = 50f; // Amplitud del movimiento horizontal
    public float amplitudeY = 30f; // Amplitud del movimiento vertical
    public float speedX = 1f;      // Velocidad del movimiento horizontal
    public float speedY = 0.8f;    // Velocidad del movimiento vertical

    private RectTransform rectTransform;
    private Vector2 originalPosition;

    void Start()
    {
        // Obtener el componente RectTransform y guardar la posición inicial
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // Calcular el desplazamiento en X y Y usando una función seno
        float offsetX = Mathf.Sin(Time.time * speedX) * amplitudeX;
        float offsetY = Mathf.Sin(Time.time * speedY) * amplitudeY;

        // Aplicar la posición oscilante
        rectTransform.anchoredPosition = originalPosition + new Vector2(offsetX, offsetY);
    }
}
