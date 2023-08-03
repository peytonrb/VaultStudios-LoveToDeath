using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] loveInterestDate;

    [TextArea(3,10)]
    public string[] friendDate;

    // [TextArea(3,10)]
    // public string[] npcConversation;
}
