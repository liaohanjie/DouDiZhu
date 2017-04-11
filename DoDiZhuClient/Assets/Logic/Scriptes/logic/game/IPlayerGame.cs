using UnityEngine;
using System.Collections;

public interface IPlayerGame{

    /// <summary>
    /// 发牌
    /// </summary>
    void SendCards();
    /// <summary>
    /// 出牌
    /// </summary>
    /// <param name="index"></param>
    void PlayCards(int index);
    /// <summary>
    /// 重选
    /// </summary>
    void ReSelectCards();
    /// <summary>
    /// 不出
    /// </summary>
    void PassOnce();
    /// <summary>
    /// 提示
    /// </summary>
    void PlayTips();
}
