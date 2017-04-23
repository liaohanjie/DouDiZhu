using UnityEngine;
using System.Collections.Generic;

public interface ICardRule {
    /// <summary>
    /// 判断牌是否符合这个规规
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
     bool isForRules(List<int> cards);
    /// <summary>
    /// 获取当前规则的类型
    /// </summary>
    /// <returns></returns>
    RuleTypeEnum getRuleType();
    /// <summary>
    /// 判断自己手中的牌是否可以大于对手的牌
    /// </summary>
    /// <param name="myCards"></param>
    /// <param name="otherCards"></param>
    /// <returns></returns>
    bool isCanPlay(List<int> myCards, List<int> otherCards);
}
