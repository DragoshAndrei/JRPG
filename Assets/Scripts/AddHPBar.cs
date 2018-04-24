using UnityEngine;
using UnityEngine.UI;

public class AddHPBar : MonoBehaviour
{
    public Text hpText;

    private void Start()
    {
        hpText.text = gameObject.GetComponent<CharacterStats>().healthPoints.ToString();
    }

    public void UpdateHPText(string newHP)
    {
        hpText.text = newHP;
    }
}
