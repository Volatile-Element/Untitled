using UnityEngine;
using System.Collections;

public class InputControls : MonoBehaviour
{
    Toolbox toolbox;

    public static GameObject Camera;


    // Use this for initialization
    void Awake()
    {
        toolbox = Toolbox.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private GameObject AddCameraIfNotExist()
    {
        var newCamera = Camera;
        if(Camera == null)
        {
            
            var newCamera = Instantiate(new GameObject(), transform.position, transform.rotation, transform);
        }
        if (Camera == null)
        {
            var camera = Instantiate(new Camera(), transform.position, transform.rotation, transform);
        }
        else
        {
            return Camera;
        }
    }*/

}
