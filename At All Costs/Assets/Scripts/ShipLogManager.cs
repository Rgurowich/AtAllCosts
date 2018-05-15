using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipLogManager : MonoBehaviour {

    public Text ShipLogText;
    public Text IntroText;

    [TextArea(3, 10)]
    public string shipLog;

    [TextArea(3, 10)]
    public string intro;

    public void StartLog()
    {
        string sentance = shipLog;
        StopAllCoroutines();
        StartCoroutine(TypeLog(sentance));
    }

    public void StartIntro()
    {
        string sentance = intro;
        StopAllCoroutines();
        StartCoroutine(TypeIntro(sentance));
    }

    IEnumerator TypeLog(string sentance)
    {
        ShipLogText.text = "";
        foreach (char letter in sentance.ToCharArray())
        {
            ShipLogText.text += letter;
            yield return null;
        }
    }

    IEnumerator TypeIntro(string sentance)
    {
        IntroText.text = "";
        foreach (char letter in sentance.ToCharArray())
        {
            IntroText.text += letter;
            yield return null;
        }
    }
}
