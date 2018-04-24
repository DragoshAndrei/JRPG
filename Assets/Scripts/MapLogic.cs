using UnityEngine;

public class MapLogic : MonoBehaviour
{

    public CharacterStats toHit;

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
            case Directon.Right:
                mapMatrix[stats.length, stats.width] = 0;
                mapMatrix[stats.length, stats.width + 1] = stats.creatureID;
                stats.width += 1;
                break;
            case Directon.Left:
                mapMatrix[stats.length, stats.width] = 0;
                mapMatrix[stats.length, stats.width - 1] = stats.creatureID;
                stats.width -= 1;
                break;
            case Directon.Down:
                mapMatrix[stats.length, stats.width] = 0;
                mapMatrix[stats.length + 1, stats.width] = stats.creatureID;
                stats.length += 1;
                break;
            case Directon.Up:
                mapMatrix[stats.length, stats.width] = 0;
                mapMatrix[stats.length - 1, stats.width] = stats.creatureID;
                stats.length -= 1;
                break;
        }
        PrintMatrix();
    }

    public void AttackObject(CharacterStats attacker)
    {
        Debug.Log("Hp before attack: " + toHit.healthPoints);
        toHit.healthPoints -= attacker.damage;
        toHit.GetComponent<AddHPBar>().UpdateHPText(toHit.healthPoints.ToString());
        if (toHit.healthPoints <= 0)
        {
            Debug.Log("Enemy dead!");
            Destroy(toHit.gameObject);
        }
        Debug.Log("Hp after attack: " + toHit.healthPoints);
    }

    public bool CheckValidMove(CharacterStats stats, Directon direction)
    {
        bool valid = false;
        switch (direction)
        {
            case Directon.Up:
                if(stats.length > 0 && mapMatrix[stats.length -1 ,stats.width] == 0)
                {
                    valid = true;
                }
                break;
            case Directon.Down:
                if (stats.length < 2 && mapMatrix[stats.length + 1, stats.width] == 0)
                {
                    valid = true;
                }
                break;
            case Directon.Left:
                if (stats.width > 0 && mapMatrix[stats.length, stats.width - 1] == 0)
                {
                    valid = true;
                }
                break;
            case Directon.Right:
                if (stats.width < 5 && mapMatrix[stats.length, stats.width + 1] == 0)
                {
                    valid = true;
                }
                break;
        }
        return valid;
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
