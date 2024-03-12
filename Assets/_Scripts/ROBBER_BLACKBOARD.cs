
using TMPro;
using UnityEngine;

public class ROBBER_BLACKBOARD : DynamicBlackboard, IDialogSystem
{

    private TextMeshPro utteranceLine;
    private GameObject bubble;
    public IDialogSystem partner = null;
    public GameObject storeEntrance;
    public GameObject exitPoint;
    public GameObject trashBag;
    public bool goodMood = true;

    public string[] utterances =
    {
        "THERES NO ONE WORKING HERE??", //0
        "GIVE ME ALL YOUR APPLES",//1
        "GIVE ME ALL YOUR PEACHES", //2
        "GIVE ME ALL THE BEERS YOU HAVE", //3
        "I HAVE TO GO FAST", // 4
        "Now let me escape the police...",
        "...and eat this f*cking fruit!",//6
        "SH*T! YOU DON'T HAVE THAT?!",
        "It was a joke! Don't call the police please...",//8
        "THIS IS A ROBBERY!!!"
    };


    void Awake()
    {
        bubble = gameObject.transform.GetChild(0).gameObject;
        utteranceLine = bubble.transform.GetChild(0).GetComponent<TextMeshPro>();
        gameObject.AddComponent<DieNear>();
        storeEntrance = GameObject.Find("storeEntrance");
        exitPoint = GameObject.Find("exitPoint");
        trashBag = transform.Find("BAG").gameObject;

        GetComponent<DieNear>().cemetery = exitPoint;
    }


    public void SetUtterance(int index)
    {
        utteranceLine.text = utterances[index];
        bubble.SetActive(true);
    }

    public void ClearUtterance()
    {
        utteranceLine.text = "";
        bubble.SetActive(false);
    }

    public string BeAsked(string question)
    {
        // a more "intelligent system would analyze the question before answering";
        int number = Random.Range(1, 4);
        SetUtterance(number);
        return utterances[number];
    }

    public void BeTold(string sentence)
    {
        // senteces with negative words affect the mood of the agent...
        if (sentence.ToUpper().Contains("DO NOT"))
        {
            goodMood = false;
        }
    }

    public bool EngageInDialog(IDialogSystem partner)
    {
        // you want to engage with someone. Use this method
        if (partner.BeEngagedInDialog(this))
        {
            this.partner = partner;
            return true;
        }
        return false; // returning false means partner has refused.
    }

    public bool BeEngagedInDialog(IDialogSystem partner)
    {
        // someone wants to talk to you. You may refuse or accept
        // this agent always accepts
        this.partner = partner;
        return true;
    }

    public void BeDisengagedFromDialog()
    {
        // a disengaged customer becomes an EX_CUSTOMER
        // else "race conditions" may re-engage it and thwart expected behaviour
        gameObject.tag = "EX_CUSTOMER";
        this.partner = null;
    }

    public void DisengageFromDialog()
    {
        throw new System.NotImplementedException();
    }

    public bool IsEngagedInDialog()
    {
        return this.partner != null;
    }

    public string Ask(int index, bool utter)
    {
        // do nothing. Customers make no questions
        return null;
    }

    public bool Tell(int index, bool utter)
    {
        // customers only answer questions
        throw new System.NotImplementedException();
    }
}
