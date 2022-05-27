using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using player;

public class Safe : MonoBehaviour
{
    string active;
    int number;

    public int code;

    int one;
    int two;
    int three;
    int four;
    Transform[] buttons;

    Transform[] numbers;
    GameObject safe;
    bool cracked;
    bool open;

    void Start()
    {
        safe = GameObject.Find("Safe");
        safe.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && open)
        {
            CloseMenu();
        }
    }

    public void OpenSafe()
    {
        if (!cracked)
        {
            OpenMenu();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().movement = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().moveDirection =
                Vector3.zero;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void OpenMenu()
    {
        open = true;
        safe.SetActive(true);
        buttons = GameObject.Find("Next").transform.GetComponentsInChildren<Transform>(true);
        numbers = GameObject.Find("Numbers").transform.GetComponentsInChildren<Transform>(true);
        active = "First";
        buttons[1].gameObject.SetActive(true);
        buttons[7].gameObject.SetActive(false);

        number = 0;
        numbers[1].GetComponent<Text>().text = number.ToString();
        numbers[2].GetComponent<Text>().text = number.ToString();
        numbers[3].GetComponent<Text>().text = number.ToString();
        numbers[4].GetComponent<Text>().text = number.ToString();
    }

    public void Next()
    {
        switch (active)
        {
            case "First":
                number++;
                if (number > 9)
                {
                    number = 0;
                }
                UpdateText();
                break;

            case "Second":
                number++;
                if (number > 9)
                {
                    number = 0;
                }
                UpdateText();
                break;

            case "Third":
                number++;
                if (number > 9)
                {
                    number = 0;
                }
                UpdateText();
                break;

            default:
                number++;
                if (number > 9)
                {
                    number = 0;
                }
                UpdateText();
                break;
        }
    }

    private void UpdateText()
    {
        switch (active)
        {
            case "First":
                numbers[1].GetComponent<Text>().text = number.ToString();
                break;

            case "Second":
                numbers[2].GetComponent<Text>().text = number.ToString();
                break;

            case "Third":
                numbers[3].GetComponent<Text>().text = number.ToString();
                break;

            default:
                numbers[4].GetComponent<Text>().text = number.ToString();
                break;
        }
    }

    public void Confirm()
    {
        switch (active)
        {
            case "First":
                active = "Second";
                buttons[1].gameObject.SetActive(false);
                buttons[3].gameObject.SetActive(true);
                one = number;
                break;

            case "Second":
                active = "Third";
                buttons[3].gameObject.SetActive(false);
                buttons[5].gameObject.SetActive(true);
                two = number;
                break;

            case "Third":
                active = "Fourth";
                buttons[5].gameObject.SetActive(false);
                buttons[7].gameObject.SetActive(true);
                three = number;
                break;

            default:
                four = number;
                CheckCode();
                CloseMenu();
                break;
        }
        UpdateText();
    }

    private void CheckCode()
    {
        if (int.Parse(one.ToString() + two.ToString() + three.ToString() + four.ToString()) == code)
        {
            cracked = true;
            Debug.Log("Open");
        }
    }

    private void CloseMenu()
    {
        open = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().movement = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (cracked)
        {
            gameObject.GetComponentInParent<Animator>().SetTrigger("Cracked");
            Destroy(safe);
        }
        else
        {
            safe.SetActive(false);
        }
    }
}
