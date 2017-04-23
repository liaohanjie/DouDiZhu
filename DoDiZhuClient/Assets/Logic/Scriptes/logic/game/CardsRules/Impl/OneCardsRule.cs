using UnityEngine;
using System.Collections.Generic;

public class OneCardsRule : ICardRule {


    public bool isForRules(List<int> cards)
    {
        if(cards.Count != 1)
        {
            return false;
        }
        return true;
    }


   public  RuleTypeEnum getRuleType()
    {
        return RuleTypeEnum.ONE_CARD;
    }

   public bool isCanPlay(List<int> myCards, List<int> otherCards)
    {
        
        if(myCards.Count == 1)
        {
            int myCard = myCards[0] % 100;
            int otherCard = otherCards[0] % 100;
            if (myCard > otherCard)
            {
                return true;
            }
        } else
        {
            ICardRule cardRule = CardRuleFacotry.getCardRule(myCards);
            if(cardRule == null)
            {
                return false;
            }
            if(cardRule.getRuleType() == RuleTypeEnum.WANG_BOMB)
            {
                return true;
            } else if(cardRule.getRuleType() == RuleTypeEnum.GENERAL_BOMB)
            {

            }
        }
       
        return false;
    }
}
