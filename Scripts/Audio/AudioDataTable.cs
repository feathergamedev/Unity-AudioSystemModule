using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AudioData
{
    public ESoundType type;
    public AudioClip clip;
}

[CreateAssetMenu(fileName = "AudioClipTable", menuName = "ScriptableObjeect/AudioClipTable")]
public class AudioDataTable : ScriptableObject
{
    public List<AudioData> list;
}
