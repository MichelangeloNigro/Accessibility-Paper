using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : SingletonDDOL<TextManager> {
    public wrapperTXT txts;
    public int maxSize;

    private void OnApplicationQuit() {
        UpdateList();
    }

    private void Start() {
        SceneManager.activeSceneChanged += AddOnChange;
        LoadSize();
    }

    private void AddOnChange(Scene current, Scene next) {
        UpdateTextsList();
    }
    
    private void UpdateTextsList() {
        foreach (var text in FindObjectsOfType<TMP_Text>()) {
            var existingTxt = txts.wrap.Find(txt => txt.name == text.name);
        Debug.Log(text.font);
            if (existingTxt != null) {
                existingTxt.size = text.fontSize;
                existingTxt.dyslexicOn = text.font == TextFinder.Instance.dislexycAsste;
            } else {
                var t = new txtsSize {
                    size = text.fontSize,
                    name = text.name,
                    dyslexicOn = text.font == TextFinder.Instance.dislexycAsste
               
            };
                txts.wrap.Add(t);
            }
        }
        UpdateList();
    }


    private void LoadSize() {
        if (File.Exists(Application.dataPath + "/textSize.json")) {
            string json = System.IO.File.ReadAllText(Application.dataPath + "/textSize.json");
            var tmp = JsonUtility.FromJson<wrapperTXT>(json);
            Debug.Log(tmp.wrap.Count);
            foreach (var txt in tmp.wrap) {
                foreach (var tmpText in FindObjectsOfType<TMP_Text>()) {
                    if (tmpText.name == txt.name) {
                        tmpText.fontSize = txt.size;
                        if (txt.dyslexicOn == true)
                        {
                            tmpText.font = TextFinder.Instance.dislexycAsste;
                        }
                    }
                }
            }
        }
    }

    private void UpdateList() {
        string json = JsonUtility.ToJson(txts);
        File.WriteAllText(Application.dataPath + "/textSize.json", json);
    }

    public void ChangeSize(float val) {
        float tmp = math.remap(0, 1, 0, maxSize, val);
        foreach (var text in TextFinder.Instance.texts) {
            text.fontSize = tmp;
        }
        UpdateTextsList();
    }
}


[System.Serializable]
public class txtsSize {
    public float size;
    public string name;
    public bool dyslexicOn=false;
}

[System.Serializable]
public class wrapperTXT {
    public List<txtsSize> wrap = new List<txtsSize>();
}
