using TMPro;
using UnityEngine;

public class BadCube : MonoBehaviour
{
    public int bonus = 10;
    public TextMeshPro bonusText;

    public void BadCubePoints()
    {
        bonusText.text = bonus.ToString();
    }


    private void OnValidate()
    {
        bonusText.text = bonus.ToString();
    }

    private void OnCollisionStay(Collision collision)
    {
        GetComponent<ParticleSystem>().Play();
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<ParticleSystem>().Stop();
    }

}


