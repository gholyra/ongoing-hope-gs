using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public static CursorManager instance;

    [SerializeField] private Texture2D interactTexture;
    [SerializeField] private Texture2D defaultTexture;

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

    // Start is called before the first frame update
    private void Start()
    {
        CursorDefault();
    }

    public void CursorInteract()
    {
        Cursor.SetCursor(interactTexture, new Vector2(10, 10), CursorMode.Auto);
    }

    public void CursorDefault()
    {
        Cursor.SetCursor(defaultTexture, new Vector2(10, 10), CursorMode.Auto);
    }

}
