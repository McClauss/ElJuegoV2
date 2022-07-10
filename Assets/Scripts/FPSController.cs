using UnityEngine;

public class FPSController : MonoBehaviour
{
    //Player Movement
    public float velocidadMovimiento = 3f;



    //Player Look Rotation
    public float sensibilidadMouse = 100f;
    public float xRotacion;
    public float yRotacion;
    public Transform cam;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
      Move();  
      MouseLook();
    }


    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hor,0,ver) * velocidadMovimiento * Time.deltaTime);
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") *sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") *sensibilidadMouse * Time.deltaTime;

        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -70,70);

        yRotacion += mouseX;//esto es asi sino funciona al reves
        cam.localRotation= Quaternion.Euler(xRotacion,yRotacion,0);
    }
}
