using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_ANITA_SEE_TO_ROBBER", menuName = "Behaviour Trees/BT_ANITA_SEE_TO_ROBBER", order = 1)]
public class BT_ANITA_SEE_TO_ROBBER : BehaviourTree
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
    public BT_ANITA_SEE_TO_ROBBER()
    {
        /* Receive BT parameters and set them. Remember all are of type string */
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
        Sequence AnitaSeeToCustomer = new Sequence(
            new ACTION_EngageInDialog("robber"),
            new ACTION_AskEngaged("1", "2", "answer"),
            new Selector(
                new Sequence(
                    new ACTION_ParseAnswer("answer", "item"),
                    new ACTION_TellEngaged("2", "2"),
                    CreateInstance<BT_ANITA_GIVE_ALL_TO_ROBBER>()
                    ),
                new ACTION_TellEngaged("3", "2")
                ),
            new ACTION_DisengageFromDialog()
            );

        root = AnitaSeeToCustomer;
    }
}
