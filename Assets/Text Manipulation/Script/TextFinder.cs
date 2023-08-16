using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextFinder : SingletonDDOL<TextFinder> {
    public List<TMP_Text> texts;
    public TMP_FontAsset dislexycAsste;
    // Start is called before the first frame update
    void Start() {
        texts= FindObjectsOfType<TMP_Text>(true).ToList();
        foreach (var text in texts) {
            text.font = dislexycAsste;
        }
    }
}
