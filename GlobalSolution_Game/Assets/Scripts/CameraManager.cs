using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class CameraManager : MonoBehaviour
{

    public static CameraManager instance;

    private Camera camera;

    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private Transform target;
    [SerializeField] private float yOffset = 0;

    private bool isTalking;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        camera = GetComponent<Camera>();
        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
        ChangeCameraSize();
    }

    private void CameraFollow()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform transform)
    {
        target = transform;
    }

    public void SetYOffset(float y)
    {
        yOffset = y;
    }

    public void ChangeCameraSize()
    {
        if(isTalking)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 3f, .8f * Time.deltaTime);
            SetYOffset(0);
        }
        else
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 4f, .8f * Time.deltaTime);
            SetYOffset(2);
        }
    }

    public void SetIsTalking(bool condition)
    {
        isTalking = condition;
    }


}
