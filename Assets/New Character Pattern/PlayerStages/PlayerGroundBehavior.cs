
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundBehavior : MonoBehaviour, IPlayerStage
{
    private TricksData trickData;
    private Dictionary<string, TrickElement> trickElements;
    private TrickHandler trickHandler;

    private TrickElement running;

    public PlayerGroundBehavior(TricksData td)
    {
        this.trickData = td;
        trickHandler = new TrickHandler(td);
        trickElements = new Dictionary<string, TrickElement>();

        running = new TrickElement(td);
        running.setAnimaSpeed(1f);
    }

    public void addTrick(TrickElement trick) => trickElements.Add(trick.getTrickName(), trick);

    public void addTrickRange(Dictionary<string, TrickElement> trickElements)
    {
        foreach (KeyValuePair<string, TrickElement> entry in trickElements)
        {
            this.trickElements.Add(entry.Key, entry.Value);
        }
    }

    public void addElementToQueue(TrickElement trick) => trickHandler.addToQueue(trick);

    public TrickElement getElementFromTrickDictionary(string trickName) => trickElements[trickName];


    public void execute()
    {
        TrickElement element = trickHandler.getFromQueue();

        if (element != null)
        {
            this.trickData.getEventGeter().rotate_method = element.rotate;
            this.trickData.getEventGeter().jump_method = element.jump;
            element.playTrick();
        }
        else
        {
            running.setAnimaSpeed(1f);
        }
    }
}
