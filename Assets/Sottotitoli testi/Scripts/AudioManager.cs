using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
     public TMP_Text container;
    public List<AudioScriptable> clipList;
    string temp="";
    public Sprite mbph;
    public Sprite sdjikt;
    public Sprite ea;
    public Sprite AE;
    public Sprite o;
    public Sprite uoo;
    public Sprite fph;
    public Image lupo;
    public AudioSource source;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int i = 0;
            i = Random.Range(0, clipList.Count);
            StopAllCoroutines();
            StartCoroutine(StampSentence(clipList[i]));
        }
    }

    public IEnumerator StampSentence(AudioScriptable audioscript)
    {
        source.clip = audioscript.audioClip;
        source.Play();
        foreach (char c in audioscript.transcript) {
            temp += c;
            container.text = temp;
            if (c == 'm'| c == 'b'| c == 'p' | c == 'h'| c=='n') {
            lupo.sprite = mbph;            
            }else if (c=='s'| c == 'd' | c == 'j' | c == 'i' | c == 'k' | c == 't'|c=='y')
            {
                lupo.sprite = sdjikt;

            }
            else if (c == 'e' | c == 'a')
            {
                lupo.sprite = ea;

            }
            else if (c == 'E' | c == 'A' )
            {
                lupo.sprite = ea;

            }
            else if (c == 'o')
            {
                lupo.sprite = o;

            }
            else if (c == 'u' )
            {
                lupo.sprite = uoo;

            }
            else if (c == 'f')
            {
                lupo.sprite = fph;

            }
            yield return new WaitForSeconds(audioscript.charPerSec);
        }
        source.Stop();
        temp = "";
        lupo.sprite = mbph;
        container.text=temp;
    }

}
