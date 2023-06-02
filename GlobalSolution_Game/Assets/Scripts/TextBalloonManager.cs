using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBalloonManager : MonoBehaviour
{
    public static TextBalloonManager instance;

    [SerializeField] private TextMeshProUGUI textComponent;

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
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAndShowBalloon(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
    }

}
