using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI icons;
    private CursorManager cursor;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            icons.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        
    }

    public void OnHovering()
    {
        icons.gameObject.SetActive(true);
    }
}
