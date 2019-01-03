using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallBehavior : MonoBehaviour, IPlayerStage
{
    private TricksData trickData;
    private Dictionary<string, TrickElement> trickElements;
    private TrickHandler trickHandler;

    private TrickElement falling;

    public PlayerFallBehavior(TricksData td)
    {
        this.trickData = td;
        trickHandler = new TrickHandler(td);
        trickElements = new Dictionary<string, TrickElement>();

        falling = new TrickElement(td);
        falling.setTrickName("Falling");
        falling.setAnimaSpeed(100f);

    }

    public void addTrick(TrickElement trick) => trickElements.Add(trick.getTrickName(),trick);

    public void addTrickRange(Dictionary<string, TrickElement> trickElements)
    {
        foreach (KeyValuePair<string, TrickElement> entry in trickElements) {
            this.trickElements.Add(entry.Key,entry.Value);
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
            element.playTrick();
        }
        else
        {
            // trickElements["ForwardFlip_F"].playTrick();
            // falling.setAnimaSpeed(100f);
            
            falling.playTrick();
        }
    }

}
