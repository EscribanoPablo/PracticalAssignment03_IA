using BTs;

public class CONDITION_CheckIfHasBeenRobbed : Condition
{
    public override bool Check()
    {
        ANITAs_BLACKBOARD blackboard = GetComponent<ANITAs_BLACKBOARD>();
        if (blackboard != null) return blackboard.CheckIfHasBeenRobbed();
        else return false;
    }

}
