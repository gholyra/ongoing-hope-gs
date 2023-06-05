using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Object : MonoBehaviour
{

    [SerializeField] private string message;
    private bool hovering;
    private bool canClick;

    // Start is called before the first frame update
    void Start()
    {
        hovering = false;
        canClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        RayCastObject();
        CheckCursor();
        OnClick();
    }

    private void RayCastObject()
    {
        Debug.DrawRay(GetMousePosition(), -Vector3.up * 10, Color.white, 0);
        RaycastHit2D hit = Physics2D.Raycast(GetMousePosition(), -Vector2.up, LayerMask.GetMask("Object"));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("InteractiveObject"))
            {
                Debug.Log("Hovering");
                hovering = true;
                canClick = true;
            }
        }
        else if(hit.collider == null || !hit.collider.gameObject.CompareTag("InteractiveObject"))
        {
            hovering = false;
            canClick = false;
        }
    }

    private void CheckCursor()
    {
        if(hovering)
        {
            CursorManager.instance.CursorInteract();
        }
        else
        {
            CursorManager.instance.CursorDefault();
        }
    }

    private void OnClick()
    {
        if(canClick)
        {
            if(Input.GetMouseButtonDown(0) && !TextBalloonManager.instance.GetIsBalloonActive())
            {
                StartCoroutine(EnableTalkSettings());
                canClick = false;
                Debug.Log(canClick);
            }
            Debug.Log(canClick);
        }
    }

    private IEnumerator EnableTalkSettings()
    {
        Player.instance.SetCanMove(false);
        TextBalloonManager.instance.SetIsBalloonActive(true);
        TextBalloonManager.instance.SetAndShowBalloon(message);
        CameraManager.instance.SetTarget(this.transform);
        CameraManager.instance.SetIsTalking(true);
        yield return new WaitForSeconds(.1f);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }


}
