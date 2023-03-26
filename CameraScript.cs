using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform followTransform;

    //mapHeight and mapWidth are the number of tiles the map is as each tile is 1x1
    public float mapHeight;
    public float mapWidth;

    private float camY, camX;
    private float camOrthSize;
    private float cameraRatio; 
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
        camOrthSize = mainCam.orthographicSize;
        cameraRatio = ((mapWidth / 2) + camOrthSize) / 2.0f;
    }

    //update is called once per frame
    private void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, -(mapHeight / 2) + camOrthSize, (mapHeight / 2) - camOrthSize);
        camX = Mathf.Clamp(followTransform.position.x, -(mapWidth / 2) + cameraRatio, (mapWidth / 2) - cameraRatio);
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
