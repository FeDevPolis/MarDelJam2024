using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    public Texture[] backgroundTextures; // Array de im�genes de fondo
    private RawImage rawImage;

    void Start()
    {
        // Obtener el componente RawImage
        rawImage = GetComponent<RawImage>();

        // Elegir una imagen aleatoria
        if (backgroundTextures.Length > 0)
        {
            Texture randomTexture = backgroundTextures[Random.Range(0, backgroundTextures.Length)];
            rawImage.texture = randomTexture;
        }

        // Aplicar filtro blanco y negro
        ApplyGrayscaleFilter();
    }

    void ApplyGrayscaleFilter()
    {
        // Accede al material del RawImage y cambia a escala de grises
        Material grayScaleMaterial = null;
        grayScaleMaterial = rawImage.material;
        grayScaleMaterial.SetFloat("_Color", 0.5f); // Ajustar el nivel de brillo
        rawImage.material = grayScaleMaterial;
    }
}
