using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using player;

public class Note : MonoBehaviour
{
    public string[] texts;

    public Canvas c;

    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            CreateText(texts[i], i);
        }

        c.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseNote();
        }
    }

    public void OpenNote()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().movement = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().moveDirection =
            Vector3.zero;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        c.enabled = true;
    }

    void CloseNote()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().movement = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        c.enabled = false;
    }

    private void CreateText(string text, int index)
    {
        GameObject message = new GameObject();
        message.transform.SetParent(c.transform);
        Text mText = message.AddComponent<Text>();
        mText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        mText.text = text;
        mText.fontSize = 50;
        mText.color = Color.black;

        message
            .GetComponent<RectTransform>()
            .SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 950);
        message
            .GetComponent<RectTransform>()
            .SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);

        int posY = 450 - (index * 100);

        message.GetComponent<RectTransform>().localPosition = new Vector3(0, posY, 0);
    }
}
