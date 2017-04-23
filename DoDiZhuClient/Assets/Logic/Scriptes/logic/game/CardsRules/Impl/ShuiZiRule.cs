using UnityEngine;
using System.Collections.Generic;

public class ShuiZiRule : ICardRule {

    public bool isForRules(List<int> cards)
    {
        if (cards.Count != 1)
        {
            return false;
        }
        return true;
    }


    public RuleTypeEnum getRuleType()
    {
        return RuleTypeEnum.SHUZI;
    }

    public bool isCanPlay(List<int> myCards, List<int> otherCards)
    {
        if (otherCards.Count != 1)
        {

        }
        return false;
    }
}
