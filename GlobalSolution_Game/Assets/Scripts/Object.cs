using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private string message;
    private Transform itemTransform;

    // Start is called before the first frame update
    void Start()
    {
        itemTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RayCastObject();
    }

    private void RayCastObject()
    {
        Debug.DrawRay(GetMousePosition(), -Vector3.up * 10, Color.white, 0);
        RaycastHit2D hit = Physics2D.Raycast(GetMousePosition(), -Vector2.up, LayerMask.GetMask("Object"));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "InteractiveObject")
            {
                Debug.Log("Hovering");
                TextBalloonManager.instance.SetAndShowBalloon(message);
            }
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }


}
