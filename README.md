# UnityModule-AudioObjectPool
Implement an easy-to-use audio player module with object pool and Resources API

## 程式碼說明
供Unity專案使用的簡易音效播放模組，出自我個人維護的FeatherTemplate。
兼顧方便性與效能，適用於Prototype、Game Jam等小規模產品，待專案音效運作流程確定後再進行改版。

## 特色

1.操作簡單，只需要維護音效類型(Enum)、音效檔案(AudioClip)之間的對照表

2.不依賴其他套件，空專案也能立即使用

3.用物件池管理AudioSource，降低效能負擔

4.可以按照不同Scene的需求，把AudioClipTable拆成很多個，只載入當下需要使用到的AudioClip資源

## 操作流程

1.在Resources建一個AudioClipTable (ScriptableObject)

2.在AudioClipTable的 list 設定 ESoundType 和 AduioClip 的對照表

3.執行AudioManager的Setup()

4.呼叫AudioManager.Instance.PlaySound(ESoundType)播放音效

5.回收已播放完畢的AudioSource

## 可優化方向

1.棄用Resources流程，改成用Addressable Group建立AudioClip的參考。

2.每個音效需要的Pitch, MaxDistance等參數可能不同，可以擴充AudioClipTable，把這些參數也紀錄進去。
