using UnityEngine;
using BTs;

public class CONDITION_RobberInStore : Condition
{

    public string m_parameterRobberOut;

    public CONDITION_RobberInStore() { }
    public CONDITION_RobberInStore(string robberOut)
    {
        m_parameterRobberOut = robberOut;
    }

    public override bool Check()
    {
        GameObject l_Robber = SensingUtils.FindInstanceWithinRadius(
            blackboard.Get<GameObject>("theStoreEntrance"), "ROBBER", 30
        );
        if (l_Robber != null)
        {
            blackboard.Put(m_parameterRobberOut, l_Robber);
            return true;
        }
        else
        {
            return false;
        }
    }

}
