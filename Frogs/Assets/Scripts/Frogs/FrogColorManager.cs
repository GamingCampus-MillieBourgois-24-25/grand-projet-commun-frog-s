using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Workshop;


public enum FrogColor
{
    Green,
    Brown,
    Purple,
    Red,
    Turquaz,
    DarkBlue,
    Dark,
    Blue,
    LightGreen,
    DarkGreen,
    Orange,
    Grey
}

[System.Serializable]
public struct ColorEntry
{
    public FrogColor Color;
    public Material FrogMat;
}
public class FrogColorManager : MonoBehaviour
{
    [SerializeField] List<ColorEntry> MatByColor;

    public void ApplyFrogColor(BaseWorkshop Workshop, FrogColor color){
        Material mat = GetColorByType(color);
        Workshop.ColorFrog = color;
        Workshop.Frog.GetComponent<Renderer>().material = mat;
    }

    public void SetRandomFrogColor(BaseWorkshop Workshop){
        ColorEntry randomColor = MatByColor[UnityEngine.Random.Range(0, MatByColor.Count)];
        ApplyFrogColor(Workshop,randomColor.Color);
    }

        Material GetColorByType(FrogColor color)
        {
            foreach (var entry in MatByColor)
            {
                if (entry.Color == color)
                {
                    return entry.FrogMat;
                }
            }
            return null;
        }

}


