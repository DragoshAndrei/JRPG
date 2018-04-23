using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject[] combatUnits;
    public MapLogic mapLogic;
    public Material toHighlight;

    private Material toKeepForReference;
    private int i = 0;

    private void Start()
    {
        toKeepForReference = combatUnits[0].GetComponent<Renderer>().material;
        combatUnits[0].GetComponent<Renderer>().material = toHighlight;
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
            Debug.Log("I got at the end of N");
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("I pressed A");
            mapLogic.Instance.MoveObject(combatUnits[i].gameObject.GetComponent<CharacterStats>(), MapLogic.Directon.Left);
            Vector3 position = combatUnits[i].transform.position;
            position = new Vector3(position.x - 1, position.y, position.z);
            combatUnits[i].transform.position = position;
            Debug.Log("I got at the end of A");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("I pressed D");
            mapLogic.Instance.MoveObject(combatUnits[i].gameObject.GetComponent<CharacterStats>(), MapLogic.Directon.Right);
            Vector3 position = combatUnits[i].transform.position;
            position = new Vector3(position.x + 1, position.y, position.z);
            combatUnits[i].transform.position = position;
            Debug.Log("I got at the end of D");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("I pressed W");
            mapLogic.Instance.MoveObject(combatUnits[i].gameObject.GetComponent<CharacterStats>(), MapLogic.Directon.Up);
            Vector3 position = combatUnits[i].transform.position;
            position = new Vector3(position.x, position.y, position.z + 1);
            combatUnits[i].transform.position = position;
            Debug.Log("I got at the end of W");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("I pressed S");
            mapLogic.Instance.MoveObject(combatUnits[i].gameObject.GetComponent<CharacterStats>(), MapLogic.Directon.Down);
            Vector3 position = combatUnits[i].transform.position;
            position = new Vector3(position.x, position.y, position.z - 1);
            combatUnits[i].transform.position = position;
            Debug.Log("I got at the end of S");
        }
    }
}
