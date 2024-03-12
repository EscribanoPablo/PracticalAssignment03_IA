using BTs;

public class ACTION_GiveAll : Action
{
    public string keyItem;

    public ACTION_GiveAll(string keyItem)
    {
        this.keyItem = keyItem;
    }

    private ANITAs_BLACKBOARD bl;
    string item;

    public override void OnInitialize()
    {
        bl = (ANITAs_BLACKBOARD)blackboard;
        item = bl.Get<string>(keyItem);
    }

    public override Status OnTick()
    {
        if (bl.GiveAll(item)) return Status.SUCCEEDED;
        else return Status.FAILED;

    }
}
