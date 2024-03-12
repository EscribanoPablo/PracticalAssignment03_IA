using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_SELL_PRODUCT", menuName = "Behaviour Trees/BT_SELL_PRODUCT", order = 1)]
public class BT_SELL_PRODUCT : BehaviourTree
{
    /* If necessary declare BT parameters here. 
       All public parameters must be of type string. All public parameters must be
       regarded as keys in/for the blackboard context.
       Use prefix "key" for input parameters (information stored in the blackboard that must be retrieved)
       use prefix "keyout" for output parameters (information that must be stored in the blackboard)

       e.g.
       public string keyDistance;
       public string keyoutObject 

       NOTICE: BT's with parameters cannot be constructed using ScriptableObject.CreateInstance<>
       An explicit constructor with new must be used. Unity will complain...
       Whenever possible, use parameter-less BT's. Use blackboard to pass information.
       TOP-level BTs (those attached to the executor) cannot have parameters
       
       In future versions, BT parameters may cease to exit

     */

    // construtor
    ANITAs_BLACKBOARD m_ANITAs_BLACKBOARD;
    public BT_SELL_PRODUCT()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    string ChooseBetween(int a, int b)
    {
        int l_C=Random.Range(1, 3);
        int l_D;
        if (l_C==1)
        {
            l_D=a;
        }
        else
        {
            l_D = b;
        }
        //Debug.Log(d);
        return l_D.ToString();
    }

    void UsageExamlpe() 
    {
        ChooseBetween(15, 9);
    }

    string ChooseRandomNegativeUtteranceIndex()
    {
        m_ANITAs_BLACKBOARD = FindObjectOfType<ANITAs_BLACKBOARD>();
        if (m_ANITAs_BLACKBOARD.m_NegativeUtterancesIndex.Count == 0)
        {
            Debug.LogError("m_NegativeUtterancesIndex is empty!");
            return "-1";
        }

        int randomIndex = Random.Range(0, m_ANITAs_BLACKBOARD.m_NegativeUtterancesIndex.Count);
        return m_ANITAs_BLACKBOARD.m_NegativeUtterancesIndex[randomIndex].ToString();

    }
    public override void OnConstruction()
    {
        /* Write here (method OnConstruction) the code that constructs the Behaviour Tree 
           Remember to set the root attribute to a proper node
           e.g.
            ...
            root = new Sequence();
            ...

          A behaviour tree can use other behaviour trees.  
      */
        
        root = new Selector(
            new Sequence(
                new CONDITION_CheckExistences("item"),
                new ACTION_Sell("item"),
                new ACTION_TellEngaged("14","2")
                ),
            new ACTION_TellEngaged(ChooseRandomNegativeUtteranceIndex(),"2")
            );
    }
}
