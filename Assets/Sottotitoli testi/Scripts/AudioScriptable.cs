using Sirenix.OdinInspector;
using System;
using UnityEngine;
[Serializable]
 

[CreateAssetMenu(fileName = "Audio_", menuName = "AudioManager/Create an Audio Object")]
public class AudioScriptable : ScriptableObject
{
    public enum AudioType
    {
        SFX,
        MUSIC,
        DUB
    }
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1;
    [Range(-3, 3)] public float pitch = 1;
    [ShowIf("@type==AudioType.MUSIC")]
    [Tooltip("This int is used to determines the time to fade the audio in")] public int timeFadeIn = 1;
    [ShowIf("@type==AudioType.MUSIC")]
    [Tooltip("This int is used to determines the time to fade the audio out")] public int timeFadeOut = 1;
    [HideIf("@type==AudioType.DUB")]
    public bool loop;
    [ShowIf("@type==AudioType.MUSIC")]
    public AnimationCurve audioFadeIn;
    [ShowIf("@type==AudioType.MUSIC")]
    public AnimationCurve audioFadeOut;
    [Tooltip("This field determines what kind of audio it is and how the manager is gonna treat it")] public AudioType type;
    [ShowIf("@type==AudioType.DUB"), Tooltip("This is the text that will be shown")]
    public string transcript;
    [ShowIf("@type==AudioType.DUB"), Tooltip("This is the speed at which the text is gonna appear")]
    public float charPerSec;

}
