using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextBalloonManager : MonoBehaviour
{
    public static TextBalloonManager instance;

    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    private int index;

    private bool isBaloonActive;

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
        isBaloonActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopCoroutine(TypeLine());
                textComponent.text = lines[index];
            }
        }

    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetAndShowBalloon(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
        SetIsBalloonActive(true);
        StartDialogue();
    }

    public void SetAndHideBalloon() 
    {
        gameObject.SetActive(false);
        SetIsBalloonActive(false);
    }

    public bool GetIsBalloonActive()
    {
        return isBaloonActive;
    }

    public void SetIsBalloonActive(bool condition)
    {
        isBaloonActive = condition;
    }

}
