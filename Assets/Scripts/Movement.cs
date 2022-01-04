using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 10;
    public float Sensitivity = 5;
    public int Points = 10;
    public Rigidbody Head;
    public TextMeshPro PointsText;

    public SnakeTail componentSnakeTail;
    private Vector3 PreviousMousePosition;
    private float sidewaysSpeed;

    public Game Game;
    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();       
        for (int i = 0; i < Points; i++) componentSnakeTail.AddCircle();
        PointsText.text = Points.ToString();
    }

    void FixedUpdate() //Update()
    {

        if (Input.GetMouseButton(0))
         {
            Vector3 delta = Input.mousePosition - PreviousMousePosition;
            Head.AddForce(delta.x * Sensitivity, 0, 0);
         }
         else if (Input.GetMouseButton(0))
         {
            MoveForward();
         }

        PreviousMousePosition = Input.mousePosition;
    }

    public void OnCollisionStay(Collision collision)
    {

        if (collision.collider.TryGetComponent(out BadCube badSector))
        {  
            if(Points > 0)
            {
                Points--;
                badSector.bonus--;
                componentSnakeTail.RemoveCircle();
                audioData.Play();
                PointsText.text = Points.ToString();
                badSector.BadCubePoints();
            }
        

            if (Points <= 0)
            {        
                Game.OnSnakeDied();
            }

            if (badSector.bonus == 0)
            {
              Destroy(badSector.gameObject);
            }
        }
        

        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        Head.velocity = new Vector3(sidewaysSpeed * 10, 0, Speed);
        sidewaysSpeed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CirleOfLife eat))
        {
            for (int i = 0; i < eat.bonus; i++)
            {
                Points++;
                componentSnakeTail.AddCircle();
                PointsText.text = Points.ToString();
            }
            Destroy(eat.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.forward);
        if (dot < 0.5) return;
    }


    public void MoveForward()
    {
        Head.AddForce(Vector3.forward * Speed);
    }
}
