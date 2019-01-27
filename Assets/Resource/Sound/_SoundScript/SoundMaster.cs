using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 必要なデータの格納場所として作用する目的
/// 元データ、作業内容などを保存できるようにしたい
/// </summary>

public class SoundMaster : MonoSingleton<SoundMaster>
{

    public Once_Action[] list_size;

    [System.Serializable]
    public class Once_Action
    {

        public string Sound_Name;//音源の名前
        public AudioClip audioclip;//音源本体

        [SerializeField, HeaderAttribute("Select either（開始時のみ影響します）")] //項目の前にあるタイトル

        public bool ChannelBase;
        public bool ObjectBase;

        [Space(10)]
        public SurroundChanger Change;

        public bool sampleshot = false;

        [TooltipAttribute("何かとの接触時に音を鳴らしたいとき\nそのターゲットのタグの名前を書く")]
        public string target_tag_name;

        [Range(-1, 1), TooltipAttribute("パンニング\n（－1が完全に左、1で完全に右になります）\n（channelbaseの時しか機能しません）")]
        public float pan_states = 0;

    }

    [System.Serializable]
    public class SurroundChanger
    {
        [TooltipAttribute("異なるBaseに遷移開始")]
        public bool Change_now_origin; // 変更開始のトリガー

        [TooltipAttribute("何秒で遷移するかの秒数")]
        public float Rate_of_change; //変化率(何秒で100％遷移するか)

        [Range(0, 1), TooltipAttribute("ChannelBaseとObjectBaseのブレンド率\n（0でchannelbase、1でObjectBaseになります）")]
        public float Rate_now = 0; //ChannelBase（0のとき）とObjectBase（１のとき）のブレンド率　
    }

    /// <summary>
    /// とりあえず一発鳴らして試す用
    /// Master側にチェックボックスがある
    /// </summary>
    /// <param name="shot"></param>
    /// <param name="audioSource"></param>
    /// <param name="soundmaster"></param>
    /// <param name="child_audioclip"></param>
    /// <param name="child_number"></param>
    public void SampleShot(bool shot, AudioSource audioSource, SoundMaster soundmaster, AudioClip child_audioclip, int child_number)
    {
        if (shot)
        {
            audioSource.PlayOneShot(child_audioclip);
            soundmaster.list_size[child_number].sampleshot = false;
        }
    }

    /// <summary>
    /// 用途として最初のチャンネル状態の設定用
    /// Master側にチェックボックスがある。
    /// </summary>
    /// <param name="Channel"></param>
    /// <param name="Object"></param>
    /// <param name="audioSource"></param>
    /// <param name="soundmaster"></param>
    /// <param name="child_number"></param>
    public void FirstBase(bool Channel, bool Object, AudioSource audioSource, SoundMaster soundmaster, int child_number)
    {
        //もしもどちらにもチェックが入っていたら、もしくはどちらにもチェックがはいっていなかったら強制的にChannelBaseにする
        if (!Channel && !Object) Channel = true;
        else if (Channel && Object) Channel = true;

        //最初期Base切り替え
        if (Channel) audioSource.spatialBlend = 0;
        else audioSource.spatialBlend = 1;

        //設定したベースと同じになるように現在のブレンド率を変更
        soundmaster.list_size[child_number].Change.Rate_now = audioSource.spatialBlend;

    }

    /// <summary>
    /// 用途としてチャンネルの変更用
    /// Master側に操作用のバーとチェックボックスがある。
    /// Change_now_originがチェックされることで変更を開始する。changeRateは何秒間で2D↔3Dの切り替えをするかの値。
    /// nowRateは今の2D3Dのブレンド率
    /// </summary>
    /// <param name="Change_now_origin"></param>
    /// <param name="nowChannel"></param>
    /// <param name="changeRate"></param>
    /// <param name="nowRate"></param>
    /// <param name="audioSource"></param>
    public void BaseChanger(ref bool Change_now_origin, bool nowChannel, float changeRate, ref float nowRate, AudioSource audioSource)
    {

        //変更が実行されていない間はnowRateのバーのブレンド率となる
        if (!Change_now_origin)
        {
            audioSource.spatialBlend = nowRate;
            if (audioSource.spatialBlend >= 0.5) nowChannel = false;
            else nowChannel = true;
            //Debug.Log("Don't_Change_now_origin");
        }
        //自動でchangeRateで指定された時間で遷移する
        if (Change_now_origin)
        {
            if (!nowChannel)
            {
                audioSource.spatialBlend -= Time.deltaTime / changeRate;
                if (audioSource.spatialBlend <= 0)
                {
                    nowRate = 0;
                    Change_now_origin = false;
                }
            }
            else
            {
                audioSource.spatialBlend += Time.deltaTime / changeRate;
                if (audioSource.spatialBlend >= 1)
                {
                    nowRate = 1;
                    Change_now_origin = false;
                }
            }
            // Debug.Log("Change_now_origin" + audioSource.spatialBlend);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="child_audioclip"></param>
    /// <param name="target_tag"></param>
    /// <param name="target_tag_name"></param>
    public void ContactShot(AudioSource audioSource, AudioClip child_audioclip, string target_tag, string target_tag_name)
    {
        if (target_tag == target_tag_name) audioSource.PlayOneShot(child_audioclip);
    }

}
