using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchRotate : MonoBehaviour
{
    public float speed;
    //public GameObject Kapitul;
    //private void OnMouseDrag()
    //{
    //    Debug.Log("Mouse Dragging");
    //    float rotX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
    //    float rotY = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

    //    Kapitul.transform.RotateAround(Vector3.up, -rotX);
    //    Kapitul.transform.RotateAround(Vector3.right, rotY);

    //}

    public InputField x_c;
    public InputField y_c;
    public InputField z_c;


    private float rotationRate = 3.0f;

    private void Start()
    {

        x_c.text = transform.position.x.ToString();
        y_c.text = transform.position.y.ToString();
        z_c.text = transform.position.z.ToString();



        x_c.onEndEdit.AddListener(delegate { ValueChangeCheck(x_c); });
        y_c.onEndEdit.AddListener(delegate { ValueChangeCheck(y_c); });
        z_c.onEndEdit.AddListener(delegate { ValueChangeCheck(z_c); });
    }

    void Update()
    {
        // get the user touch inpun
        foreach (Touch touch in Input.touches)
        {
            Debug.Log("Touching at: " + touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch phase began at: " + touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Touch phase Moved");
                transform.Rotate(touch.deltaPosition.y * rotationRate,
                                 -touch.deltaPosition.x * rotationRate, 0, Space.World);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch phase Ended");
            }
        }
    }

    public void ValueChangeCheck(InputField input)
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        switch (input.name)
        {
            case "x":
                Debug.Log("X Value Changed " + input.text);
                transform.position= new Vector3(float.Parse(input.text),y,z);
                break;
            case "y":
                Debug.Log("Y Value Changed" + input.text);
                transform.position = new Vector3(x, float.Parse(input.text), z);
                break;
            case "z":
                Debug.Log("Z Value Changed" + input.text);
                transform.position = new Vector3(x, y, float.Parse(input.text));
                break;
        }

    }


}
