using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

    public Transform target;
    Camera cam;


    public float zoomSpeed = 10f;
    public float rotationSpeed = 1f;

    public float pitch = 2f;

    private float minZoom = 0.2f;
    private float maxZoom = 100f;

    private float currentZoom = 1f;  
    private float currentYaw = 0f;

    private Vector3 offset=new Vector3(0,3,3);
    private Vector3 centerView = new Vector3(0, 0, 0);
    

    private float TargetAngleX = 0f;
    private float TargetAngleY = 0f;

    private bool rotateView=false;
    private bool moveView = false;
    //private Quaternion cameraOrientation = new Quaternion()

    // Use this for initialization
    void Start () {
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        //camera position
        transform.position = centerView + offset * currentZoom;
        //transform.LookAt(centerView);
        

        if (Input.GetKey("a"))
        {
            //centerView.x += 1;
            centerView.x -= Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y);
            centerView.z += Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y);

        }
        if (Input.GetKey("d"))
        {
            //centerView.x -= 1;
            centerView.x += Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y);
            centerView.z -= Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y);

        }
        if (Input.GetKey("w"))
        {
            //centerView.z -= 1;
            centerView.x += Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y);
            centerView.z += Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y);
        }
        if (Input.GetKey("s"))
        {
            //centerView.z += 1;
            centerView.x -= Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y);
            centerView.z -= Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y);
        }
        
        /*
         * if (Input.GetKey("q"))
        {
            transform.RotateAround(centerView, Vector3.up, -rotationSpeed);
        }
        if (Input.GetKey("e"))
        {
            transform.RotateAround(centerView, Vector3.up, +rotationSpeed);
        }
        */
        if(rotateView == false){
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }
         currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        //Rotate with middle mouse button
        if (Input.GetKey(KeyCode.Mouse2))  //happens everytime the middle mouse is pressed
        {
            // TODO Bug here that makes the camera zoom in while button is pressed
            if (rotateView == false) {
                rotateView = true;
            }
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up) * offset; //horizontally
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), Vector3.right) * offset; //vertically
            //transform.position = centerView + offset;
            transform.LookAt(centerView);
        }
        if (Input.GetMouseButtonUp(2)) //when middle mouse is released
        {
            rotateView = false;
        }
        //Move camera with mouse
        if (Input.GetKey(KeyCode.Mouse0))  //happens everytime the middle mouse is pressed
        {
            
            if (moveView == false)
            {
                moveView = true;
            }
            //Move camera with mouse
            //centerView.x += Input.GetAxis("Mouse X");
            //centerView.z += Input.GetAxis("Mouse Y");
            if (Input.GetAxis("Mouse X") < 0)
            {
                //centerView.x += 1;
                centerView.x -= Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y) * Input.GetAxis("Mouse X");
                centerView.z += Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y) * Input.GetAxis("Mouse X");

            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                //centerView.x -= 1;
                centerView.x -= Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y) * Input.GetAxis("Mouse X");
                centerView.z += Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y) * Input.GetAxis("Mouse X");

            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                //centerView.z -= 1;
                centerView.x -= Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y) * Input.GetAxis("Mouse Y");
                centerView.z -= Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y) * Input.GetAxis("Mouse Y");
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                //centerView.z += 1;
                centerView.x -= Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y) * Input.GetAxis("Mouse Y");
                centerView.z -= Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y) * Input.GetAxis("Mouse Y");
            }

        }
        if (Input.GetMouseButtonUp(2)) //when middle mouse is released
        {
            moveView = false;
        }



        //Debug.Log(transform.eulerAngles+" "+ Mathf.Cos(Mathf.Deg2Rad*transform.eulerAngles.y) + " " + Mathf.Sin(Mathf.Deg2Rad*transform.eulerAngles.y) + " "+centerView);
        //Debug.Log(transform.position);
    }
    

}
