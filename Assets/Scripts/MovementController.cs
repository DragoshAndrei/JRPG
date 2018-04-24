using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject[] combatUnits;
    public MapLogic mapLogic;
    public Material toHighlight;

    private CharacterStats activeUnit;
    private Material toKeepForReference;
    private int i = 0;

    private void Start()
    {
        toKeepForReference = combatUnits[0].GetComponent<Renderer>().material;
        combatUnits[0].GetComponent<Renderer>().material = toHighlight;
        activeUnit = combatUnits[i].gameObject.GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("I pressed N");
            combatUnits[i].GetComponent<Renderer>().material = toKeepForReference;
            i++;
            if (i >= combatUnits.Length)
            {
                i = 0;
            }
            toKeepForReference = combatUnits[i].GetComponent<Renderer>().material;
            combatUnits[i].GetComponent<Renderer>().material = toHighlight;
            activeUnit = combatUnits[i].gameObject.GetComponent<CharacterStats>();
            Debug.Log("I got at the end of N");
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("I pressed A");
            if (mapLogic.Instance.CheckValidMove(activeUnit, MapLogic.Directon.Left))
            {
                mapLogic.Instance.MoveObject(activeUnit, MapLogic.Directon.Left);
                Vector3 position = combatUnits[i].transform.position;
                position = new Vector3(position.x - 1, position.y, position.z);
                combatUnits[i].transform.position = position;
            }
            Debug.Log("I got at the end of A");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("I pressed D");
            if (mapLogic.Instance.CheckValidMove(activeUnit, MapLogic.Directon.Right))
            {
                mapLogic.Instance.MoveObject(activeUnit, MapLogic.Directon.Right);
                Vector3 position = combatUnits[i].transform.position;
                position = new Vector3(position.x + 1, position.y, position.z);
                combatUnits[i].transform.position = position;
            }
            Debug.Log("I got at the end of D");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("I pressed W");
            if (mapLogic.Instance.CheckValidMove(activeUnit, MapLogic.Directon.Up))
            {
                mapLogic.Instance.MoveObject(activeUnit, MapLogic.Directon.Up);
                Vector3 position = combatUnits[i].transform.position;
                position = new Vector3(position.x, position.y, position.z + 1);
                combatUnits[i].transform.position = position;
            }
            Debug.Log("I got at the end of W");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("I pressed S");
            if (mapLogic.Instance.CheckValidMove(activeUnit, MapLogic.Directon.Down))
            {
                mapLogic.Instance.MoveObject(activeUnit, MapLogic.Directon.Down);
                Vector3 position = combatUnits[i].transform.position;
                position = new Vector3(position.x, position.y, position.z - 1);
                combatUnits[i].transform.position = position;
            }
            Debug.Log("I got at the end of S");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("I pressed LA");
            if (!mapLogic.Instance.CheckValidMove(activeUnit, MapLogic.Directon.Left))
            {
                mapLogic.Instance.AttackObject(activeUnit);
            }
            Debug.Log("I got at the end of LA");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("I pressed RA");
            if (!mapLogic.Instance.CheckValidMove(activeUnit, MapLogic.Directon.Right))
            {
                mapLogic.Instance.AttackObject(activeUnit);
            }
            Debug.Log("I got at the end of RA");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("I pressed UA");
            if (!mapLogic.Instance.CheckValidMove(activeUnit, MapLogic.Directon.Up))
            {
                mapLogic.Instance.AttackObject(activeUnit);
            }
            Debug.Log("I got at the end of UA");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("I pressed DA");
            if (!mapLogic.Instance.CheckValidMove(activeUnit, MapLogic.Directon.Down))
            {
                mapLogic.Instance.AttackObject(activeUnit);
            }
            Debug.Log("I got at the end of DA");
        }
    }
}
