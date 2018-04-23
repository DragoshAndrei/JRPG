using UnityEngine;

public class MapLogic : MonoBehaviour
{

    public enum Directon
    {
        Up,
        Down,
        Left,
        Right
    }

    private int[,] mapMatrix = new int[3,6];
    private static MapLogic m_instance;
    public MapLogic Instance
    {
        get
        {
            if (!m_instance)
            {
                return m_instance = this;
            }
            else
            {
                return m_instance;
            }
        }
    }

    private void Start()
    {
        mapMatrix[1, 2] = 1;
        mapMatrix[1, 4] = 2;
    }

    public void MoveObject(CharacterStats stats, Directon direction)
    {
        PrintMatrix();
        Debug.Log("Moving things in the Matrix");
        switch (direction)
        {
            case Directon.Up:
                mapMatrix[stats.length, stats.width] = 0;
                mapMatrix[stats.length, stats.width + 1] = stats.creatureID;
                stats.width += 1;
                break;
            case Directon.Down:
                mapMatrix[stats.length, stats.width] = 0;
                mapMatrix[stats.length, stats.width - 1] = stats.creatureID;
                stats.width -= 1;
                break;
            case Directon.Left:
                mapMatrix[stats.length, stats.width] = 0;
                mapMatrix[stats.length - 1, stats.width] = stats.creatureID;
                stats.length -= 1;
                break;
            case Directon.Right:
                mapMatrix[stats.length, stats.width] = 0;
                mapMatrix[stats.length + 1, stats.width] = stats.creatureID;
                stats.length += 1;
                break;
        }
        PrintMatrix();
    }

    private void PrintMatrix()
    {
        string matrix = "";
        for (int i = 0; i < mapMatrix.Length/3; i++)
        {
            matrix = matrix + mapMatrix[0, i] + " , " + mapMatrix[1, i] + " , " + mapMatrix[2, i] + "\n";
        }
        Debug.Log(matrix);
    }

}
