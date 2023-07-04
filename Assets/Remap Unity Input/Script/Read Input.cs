using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    private Coroutine waitingInput;
    private Dictionary<Button, string> buttonFieldMap = new Dictionary<Button, string>();
    public Button attack;
    public Button jump;
    public Button crouch;
    public Button menu;
    public Button up;
    public Button down;
    public Button right;
    public Button left;
    private KeyCode[] keyCodes;
    public InputReader reader;

    private void Start()
    {
        buttonFieldMap = new Dictionary<Button, string>
        {
            { jump, "jump" },
            { attack, "attack" },
            { menu, "menu" },
            { crouch, "crouch" },
            { up, "up" },
            { down, "down" },
            { right, "right" },
            { left, "left" }
        };

        keyCodes = (KeyCode[])Enum.GetValues(typeof(KeyCode));
    }

    public void ButtonClick(Button button)
    {
        if (waitingInput != null)
        {
            StopCoroutine(waitingInput);
        }

        if (buttonFieldMap.TryGetValue(button, out string fieldName))
        {
            waitingInput = StartCoroutine(ChangeKeyCode(fieldName, button));
        }
    }

    private IEnumerator ChangeKeyCode(string fieldName, Button button)
    {
        yield return new WaitUntil(() => Input.anyKeyDown);

        foreach (KeyCode keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
            {
                var field = typeof(KeyCodeData).GetField(fieldName);
                if (field != null)
                {
                    field.SetValue(reader.keyCodeData, keyCode);
                    reader.UpdateKeyActions();
                    var t = button.GetComponentInChildren<TMP_Text>();
                    Debug.Log($"{t.text} was remapped to {keyCode}");
                }
                else
                {
                    Debug.LogError("Field not found in InputReader: " + fieldName);
                }
                break;
            }
        }

        waitingInput = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (waitingInput != null)
            {
                StopCoroutine(waitingInput);
            }
            Debug.Log("Pooling stopped");
        }
    }
}
