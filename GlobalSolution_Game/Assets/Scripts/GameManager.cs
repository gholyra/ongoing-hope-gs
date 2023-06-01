using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameManager instance;

    [SerializeField] private TextMeshProUGUI interactIcon;

    private void Awake()
    {
        instance = this;
        interactIcon.gameObject.SetActive(false);
    }

    public void OnHovering()
    {

    }
}
