using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundChild : MonoBehaviour
{

    public string Sound_Name; //Master側で命名したほしい音の名前
    private SoundMaster soundmaster; //SoundMaster格納用
    [HideInInspector] public int child_number = 0; //向こうの配列番号を格納する用
    private AudioClip child_audioclip; //引っ張ってくるclipを格納する用
    private AudioSource audioSource; //このオブジェクトにつけたAudioSoruceを選択する用

    private bool nowChannel; // 現在のチャンネルがどちらかの判断用trueがChannelBase

    public bool start_spot;
    public bool oneshot;

    private bool playonawake = false;
    public bool loop = false;

    //private float audiotime = 0;
    //private float countaudiotime = 0;

    void Start()
    {

        //まずは子オブジェクト（このスクリプトがついたオブジェクト）についたオーディオソースを取得
        audioSource = GetComponent<AudioSource>();

        //"SoundManager"オブジェクトからSoundMasterを取得
        soundmaster = GameObject.Find("SoundManager").GetComponent<SoundMaster>();

        //playOnAwakeを通常falseに
        audioSource.playOnAwake = playonawake;

        //

        audioSource.loop = loop;

        // 最初にどこのデータを参照するか名前で指定→名前から配列番号を取得（名前間違えると悲惨なので注意）
        for (int i = 0; i < soundmaster.list_size.Length; i++)
        {
            if (Sound_Name == soundmaster.list_size[i].Sound_Name) child_number = i;
        }

        //AudioCilpを親から取得
        child_audioclip = soundmaster.list_size[child_number].audioclip;

        //AudioSource内に上記オーディオクリップを格納
        audioSource.clip = child_audioclip;

        //audiotime = child_audioclip.length;

        if (loop && oneshot)
        {
            oneshot = false;
            audioSource.Play();
        }
        //spatialBlend(2Dか3Dかの割合、ブレンド率。)→変化するようにする
        //audioSource.spatialBlend = 0;//0→2D　1→3D 
        //下記関数等で使用している

        SoundMaster.Instance.FirstBase(soundmaster.list_size[child_number].ChannelBase, soundmaster.list_size[child_number].ObjectBase, audioSource, soundmaster, child_number);

        //rolloffMode → これでmaxDistanceに影響するモードを変更する。モードはLogarithmic、Linear、Customの3種類。
        //              （Customはスクリプトからいじれないらしいので、影響があるのはLogarithmic、Linearの2種類）デフォルトはLogarithmicモードになっている。
        //               また、Unity上の該当プルダウンメニューを操作すると、maxDistanceの値に変化はなかったので、最初からモードを選択した状態でいじるのが前提になると思う
        //モードの変更は下記のようなスクリプトとなる
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic; //デフォルト通りの形なので今のところ実質意味はない

        //maxDistance→Logarithmicモードでは音が減衰を停止する距離(減衰の停止がどういう意味かは不明（volumeが0になるという意味なのかただ単に止まるだけなのか）)
        //             Linearモードでは音が完全に聞こえなくなる距離
        audioSource.maxDistance = 500; //(Logarithmicモード)デフォルト通りの形なので今のところ実質意味はない

        //minDistance→この値の外側に行くと減衰が開始される
        audioSource.minDistance = 1; //デフォルト通りの形なので今のところ実質意味はない

    }

    void Update()
    {

        soundmaster.list_size[child_number].sampleshot = oneshot;
        oneshot = false;

        //if (loop)
        //{
        //    countaudiotime += Time.deltaTime;
        //    if (countaudiotime >= audiotime)
        //    {

        //    }
        //}

        SoundMaster.Instance.SampleShot(soundmaster.list_size[child_number].sampleshot, audioSource, soundmaster, child_audioclip, child_number);

        SoundMaster.Instance.BaseChanger(ref soundmaster.list_size[child_number].Change.Change_now_origin,
                    nowChannel,
                    soundmaster.list_size[child_number].Change.Rate_of_change,
                    ref soundmaster.list_size[child_number].Change.Rate_now,
                    audioSource);

        if (nowChannel) audioSource.panStereo = soundmaster.list_size[child_number].pan_states; //channelbaseならパンを反映


        if (start_spot && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            audioSource.Play();
            start_spot = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SoundMaster.Instance.ContactShot(audioSource, child_audioclip, collision.transform.tag, soundmaster.list_size[child_number].target_tag_name);
    }


}
