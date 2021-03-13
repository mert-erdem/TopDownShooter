using UnityEngine;

public class Player : MonoBehaviour
{
    //CoreMovement
    Rigidbody fizik;
    float horizontal, vertical; 
    Vector3 horizontalVector, verticalVector, velocityVector
        , horizontalDir=new Vector3(1,0,0), verticalDir=new Vector3(0,0,1);

    [Range(1,10)]
    public int speed = 2; 
    [SerializeField]
    private Camera cam;


    [Range(1, 30)]
    public int mouseSensivity = 20;
    public static Quaternion lookDir;


    void Start()
    {
        fizik = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CoreMovement();
        CoreRotation();
    }

    private void CoreMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        horizontalVector = horizontal * horizontalDir;
        verticalVector = vertical * verticalDir;

        velocityVector = (horizontalVector + verticalVector);

        fizik.velocity = velocityVector * speed;
    }

    private void CoreRotation()
    {
        Vector3 input = Input.mousePosition;
        input.z = 10;

        Vector3 mousePos =  cam.ScreenToWorldPoint(input);
        Vector3 relativePos =new Vector3(mousePos.x - transform.position.x, transform.position.y,
            mousePos.z-transform.position.z)*mouseSensivity;

        lookDir = Quaternion.LookRotation(relativePos);

        transform.rotation = lookDir;
    }
}
