using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3,15)]
    public string[] loveInterestDate1;

    [TextArea(3,15)]
    public string[] loveInterestDate2;

    [TextArea(3,15)]
    public string[] loveInterestDate3;

    [TextArea(3,15)]
    public string[] friendDate;

    // [TextArea(3,10)]
    // public string[] npcConversation;
}
