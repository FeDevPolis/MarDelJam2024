using UnityEngine;
using System.IO;

public class Highscore : MonoBehaviour
{
    readonly static string filePath = "Assets/highscore.txt";
    
    public static int ReadHighscore()
    {
        if (File.Exists(filePath))
        {
            string score = File.ReadAllText(filePath);  // Leer el contenido del archivo
            return int.TryParse(score, out int result) ? result : 0;  // Convertir el texto a entero, o 0 si no es v�lido
        }
        else
        {
            return 0;  // Si no existe el archivo, el highscore es 0
        }
    }
    public static void SaveHighscore(int score)
    {
        File.WriteAllText(filePath, score.ToString());  // Escribir la nueva puntuaci�n en el archivo
    }
}
