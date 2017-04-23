using UnityEngine;
using System.Collections.Generic;

public class CardRuleFacotry {

    private static List<ICardRule> ruleList = new List<ICardRule>();
    
    public static void init()
    {
        ruleList.Add(new OneCardsRule());
        ruleList.Add(new DuiZiRule());
        ruleList.Add(new ShuiZiRule());
    }

    public static ICardRule getCardRule(List<int> cards)
    {
        foreach(ICardRule cardRule in ruleList)
        {
            if (cardRule.isForRules(cards))
            {
                return cardRule;
            }
        }
        return null;
    }
}
