using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class KeyCodeData
{
    public KeyCode jump = KeyCode.Space;
    public KeyCode attack = KeyCode.LeftAlt;
    public KeyCode menu = KeyCode.Escape;
    public KeyCode crouch = KeyCode.LeftControl;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
}
public class InputReader : MonoBehaviour
{
    private Dictionary<KeyCode, Action<bool>> keyActions;
    public TMP_Text jumpImg;
    public TMP_Text attackImg;
    public TMP_Text crouchImg;
    public TMP_Text menuImg;
    public Image upImg;
    public Image downImg;
    public Image rightImg;
    public Image leftImg;
    public KeyCodeData keyCodeData=new KeyCodeData();


    private void Awake()
    {
        UpdateKeyActions();
    }
    private void Update()
    {
        foreach (var keyAction in keyActions)
        {
            bool keyDown = Input.GetKeyDown(keyAction.Key);
            bool keyUp = Input.GetKeyUp(keyAction.Key);

            if (keyDown || keyUp)
            {
                keyAction.Value.Invoke(keyDown);
            }
        }
    }

    public void UpdateKeyActions()
    {
        keyActions = new Dictionary<KeyCode, Action<bool>>
        {
            { keyCodeData.jump, UpdateJump },
            { keyCodeData.attack, UpdateAttack },
            { keyCodeData.menu, UpdateMenu },
            { keyCodeData.crouch, UpdateCrouch },
            { keyCodeData.up, UpdateMoveUp },
            { keyCodeData.down, UpdateMoveDown },
            { keyCodeData.right, UpdateMoveRight },
            { keyCodeData.left, UpdateMoveLeft }
        };
    }
    public void SaveKeyCodeData()
    {
        string json = JsonUtility.ToJson(keyCodeData);
        System.IO.File.WriteAllText(Application.dataPath +"/keycode_data.json", json);
        Debug.Log("KeyCode data saved to JSON.");
    }
    public void LoadKeyCodeData()
    {
        string path = Application.dataPath + "/keycode_data.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            keyCodeData = JsonUtility.FromJson<KeyCodeData>(json);
            Debug.Log("KeyCode data loaded from JSON.");
        }
    }



        private void UpdateJump(bool isPressed)
    {
        jumpImg.color = isPressed ? Color.green : Color.black;
    }

    private void UpdateAttack(bool isPressed)
    {
        attackImg.color = isPressed ? Color.green : Color.black;
    }

    private void UpdateMenu(bool isPressed)
    {
        menuImg.color = isPressed ? Color.green : Color.black;
    }

    private void UpdateCrouch(bool isPressed)
    {
        crouchImg.color = isPressed ? Color.green : Color.black;
    }

    private void UpdateMoveUp(bool isPressed)
    {
        upImg.color = isPressed ? Color.green : Color.white;
    }

    private void UpdateMoveDown(bool isPressed)
    {
        downImg.color = isPressed ? Color.green : Color.white;
    }

    private void UpdateMoveRight(bool isPressed)
    {
        rightImg.color = isPressed ? Color.green : Color.white;
    }

    private void UpdateMoveLeft(bool isPressed)
    {
        leftImg.color = isPressed ? Color.green : Color.white;
    }
}
