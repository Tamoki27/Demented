using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonScript : MonoBehaviour {

    [SerializeField]
    public float sensitivity = 1.0f;
    [SerializeField]
    public float smoothing = 1.0f;
    public GameObject character; 
    private Vector2 mouseLook;
    private Vector2 smoothV;

    private float yRot;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //constricting camera y view
        yRot = Mathf.Min(50, Mathf.Max(-50, yRot + Input.GetAxis("Mouse Y")));

        // md is mouse delta
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis
        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        transform.localRotation = Quaternion.AngleAxis(yRot, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

    }
}

