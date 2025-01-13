
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    public Vector2 randomForce, randomTorque;
    public float xRange;

    [SerializeField] int scoreChange, livesChange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Gets access to rigid body
        rb = GetComponent<Rigidbody>();

        //add random upward force
        rb.AddForce(Vector3.up * Random.Range(randomForce.x, randomForce.y), ForceMode.Impulse);

        //add random torque and rotation
        rb.AddTorque(Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), ForceMode.Impulse);


        //random start position
        transform.position = new Vector3(Random.Range(-xRange, xRange), -1, 0);
       

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2) Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        //if (transform.tag == "GoodObject") FindFirstObjectByType<GameManager>().score++;
        // if (transform.tag == "GoodObject") FindFirstObjectByType<GameManager>().updateUI(scoreChange);

        //else FindFirstObjectByType<GameManager>().lives--;
        
        FindFirstObjectByType<GameManager>().updateUI(scoreChange, livesChange);
        
        Destroy(gameObject);
        
    }
} 
