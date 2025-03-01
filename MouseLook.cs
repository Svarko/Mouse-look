using UnityEngine;

public class MouseLook : MonoBehaviour { 

 public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 } 
  public RotationAxes axes = RotationAxes.MouseXAndY; 
  public float mouseSensitivity = 100f; // Чувствительность мыши

   // Ограничение вращения по оси X/Y
  public float minimumX = -9F; 
  public float maximumX = 9F; 

  public float minimumY = -9F; 
  public float maximumY = 9F; 

  float rotationX = 0F; 
  float rotationY = 0F;

  void Update () 
  { 
    if (axes == RotationAxes.MouseY) 
    { 
      float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse Y") * mouseSensitivity; 
      
      rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity; 
      rotationY = Mathf.Clamp (rotationY, minimumY, maximumY); 
      
      transform.localEulerAngles = new Vector3(-rotationY, rotationY, 2); 
    } 
   
    else 
    { 
      rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity; 
      rotationY = Mathf.Clamp (rotationY, minimumY, maximumY); 
      
      transform.localEulerAngles = new Vector3(-rotationX, transform.localEulerAngles.y, 2); 
    }
 
    if (axes == RotationAxes.MouseX) 
    { 
      float rotationX = transform.localEulerAngles.x + Input.GetAxis("Mouse X") * mouseSensitivity; 
      
      rotationX -= Input.GetAxis("Mouse X") * mouseSensitivity; 
      rotationX = Mathf.Clamp (rotationX, minimumX, maximumX); 
      
      transform.localEulerAngles = new Vector3(-rotationX, rotationX, 1); 
    } 
  
    else 
    { 
      rotationX -= Input.GetAxis("Mouse X") * mouseSensitivity; 
      rotationX = Mathf.Clamp (rotationX, minimumX, maximumX); 
      
      transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.x, 1); 
    } 

  } 
  
  void Start () 
  { 
    // Make the rigid body not change rotation 
    if (GetComponent<Rigidbody>()) 
      GetComponent<Rigidbody>().freezeRotation = true; 

    {
        // Скрыть курсор и заблокировать его в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
    }
  } 
}