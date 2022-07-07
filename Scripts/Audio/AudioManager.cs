using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioManager : MonoSingleton<AudioManager>
{
    private Dictionary<ESoundType, AudioClip> soundClipDic = new Dictionary<ESoundType, AudioClip>();
    private GameObjectPool<AudioSource> audioSourcePool;
    private AudioDataTable audioDataTable;

    public void Setup()
    {
        var prefab = Resources.Load<AudioSource>(AudioConfig.AUDIO_SOURCE_PREFAB_PATH);
        audioSourcePool = new GameObjectPool<AudioSource>(prefab, AudioConfig.AUDIO_SOURCE_POOL_SIZE);
        audioDataTable = Resources.Load<AudioDataTable>(AudioConfig.AUDIO_DATA_TABLE_PATH);

        var list = audioDataTable.list;

        foreach (AudioData data in list)
        {
            soundClipDic.Add(data.type, data.clip);
            print($"Audio clip loaded - {data.type}");
        }
    }

    public void PlaySound(ESoundType type)
    {
        var source = audioSourcePool.GetObject();
        source.clip = soundClipDic[type];
        source.Play();
    }
}
