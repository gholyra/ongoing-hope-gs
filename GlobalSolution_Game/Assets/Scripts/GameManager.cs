using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager instance;

    [SerializeField] private TextMeshProUGUI icons;

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

    public void OnHovering()
    {
        icons.gameObject.SetActive(true);
    }
}
