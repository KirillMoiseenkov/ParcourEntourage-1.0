using UnityEngine;
using System.Collections;

public class CameraBinder : MonoBehaviour
{
    protected Vector3 camera_offset;
    protected Camera cam;
    protected TricksData tricksData;
    protected bool mode = false;
    public void init(Camera cam, TricksData tricksData, Vector3 camera_offset)
    {
        this.tricksData = tricksData;
        this.cam = cam;
        this.camera_offset = camera_offset;
    }

    public void cameraUpdate()
    {
            cam.transform.position =
                this.camera_offset +
                tricksData.getCharacter().transform.position;
          
     }
}
