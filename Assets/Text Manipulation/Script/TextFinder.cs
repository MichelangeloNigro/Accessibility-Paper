using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextFinder : SingletonDDOL<TextFinder> {
    public List<TMP_Text> texts;
    public TMP_FontAsset dislexycAsste;
    public TMP_FontAsset defaultAsset;
    // Start is called before the first frame update
    void Start() {
        texts= FindObjectsOfType<TMP_Text>(true).ToList();
        //foreach (var text in texts) {
        //    text.font = dislexycAsste;
        //}
    }
    public void DyslexicOne(bool i)
    {
        if (i)
        {
            foreach (var text in texts)
            {
                text.font = dislexycAsste;
            }
        }
        else
        {
            foreach (var text in texts)
            {
                text.font = defaultAsset;
            }
        }
    }
}
