using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public CursorManager instance;

    [SerializeField] private Texture2D cursorTexture;
    // Start is called before the first frame update

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

    private void Start()
    {
        
    }

    public void CursorInteract()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(10, 10), CursorMode.Auto);
    }

}
