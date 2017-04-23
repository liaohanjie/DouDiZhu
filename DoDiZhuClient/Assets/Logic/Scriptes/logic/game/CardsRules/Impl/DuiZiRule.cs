using UnityEngine;
using System.Collections.Generic;

public class DuiZiRule : ICardRule {

    public bool isForRules(List<int> cards)
    {
        if (cards.Count != 2)
        {
            return false;
        }
        return true;
    }


    public RuleTypeEnum getRuleType()
    {
        return RuleTypeEnum.DUI_ZI_CARD;
    }

    public bool isCanPlay(List<int> myCards, List<int> otherCards)
    {
       
        return false;
    }
}
