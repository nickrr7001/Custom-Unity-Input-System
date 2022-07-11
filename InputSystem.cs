using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem instance;
    public KeyControl[] keys;
    public MBControl[] MouseKeys;
    private Dictionary<string, int> keyDict = new Dictionary<string, int>();
    private Dictionary<string, int> mouseKeyDict = new Dictionary<string, int>();
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < keys.Length; i++)
        {
            keyDict.Add(keys[i].key, i);
        }
        for (int i = 0; i < MouseKeys.Length; i++)
        {
            mouseKeyDict.Add(MouseKeys[i].key, i);
        }
    }
    private void Update()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].setBools();
        }
        for (int i = 0; i < MouseKeys.Length; i++)
        {
            MouseKeys[i].setBools();
        }
    }
    public bool keyDown(string k)
    {
        bool retVal = keys[keyDict[k]].keyDown;
        if (!retVal)
        {
                retVal = Input.GetKeyDown(keys[keyDict[k]].controllerInput);
        }
        return retVal;
    }
    public bool keyUp(string k)
    {
        bool retVal = keys[keyDict[k]].keyUp;
        if (!retVal)
        {
            retVal = Input.GetKeyUp(keys[keyDict[k]].controllerInput);
        }
        return retVal;
    }
    public bool keyHold(string k)
    {
        bool retVal = keys[keyDict[k]].keyHeld;
        if (!retVal)
        {
            retVal = Input.GetKey(keys[keyDict[k]].controllerInput);
        }
        return retVal;
    }
    public bool mouseDown(string k)
    {
        bool retVal = MouseKeys[mouseKeyDict[k]].keyDown;
        if (!retVal)
        {
            retVal = Input.GetKeyDown(MouseKeys[mouseKeyDict[k]].controllerInput);
        }
        return retVal;
    }
    public bool mouseUp(string k)
    {
        bool retVal = MouseKeys[mouseKeyDict[k]].keyUp;
        if (!retVal)
        {
            retVal = Input.GetKeyUp(MouseKeys[mouseKeyDict[k]].controllerInput);
        }
        return retVal;
    }
    public bool mouseHold(string k)
    {
        bool retVal = MouseKeys[mouseKeyDict[k]].keyHeld;
        if (!retVal)
        {
            retVal = Input.GetKey(MouseKeys[mouseKeyDict[k]].controllerInput);
        }
        return retVal;
    }
}
[System.Serializable]
public class KeyControl
{
    public string key;
    public KeyCode keyCode;
    public bool keyDown;
    public bool keyUp;
    public bool keyHeld;
    public bool controllerisAxis;
    public KeyCode controllerInput;
    public void setBools()
    {
        keyDown = Input.GetKeyDown(keyCode);
        keyUp = Input.GetKeyUp(keyCode);
        keyHeld = Input.GetKey(keyCode);
    }
}
[System.Serializable]
public class MBControl
{
    public string key;
    public int keyCode;
    public bool keyDown;
    public bool keyUp;
    public bool keyHeld;
    public bool controllerisAxis;
    public KeyCode controllerInput;
    public void setBools()
    {
        keyDown = Input.GetMouseButtonDown(keyCode);
        keyUp = Input.GetMouseButtonUp(keyCode);
        keyHeld = Input.GetMouseButton(keyCode);
    }
}
