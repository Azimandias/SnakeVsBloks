using TMPro;
using UnityEngine;

public class CirleOfLife : MonoBehaviour
{
    public int bonus = 10;
    public TextMeshPro bonusText;

/*    private void Start()
    {
        bonusText.text = bonus.ToString();
    }*/

    public void BadCubePoints()
    {
        bonusText.text = bonus.ToString();
    }
    private void OnValidate()
    {
        bonusText.text = bonus.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
       // GetComponent<AudioSource>().Play();
    }

}
