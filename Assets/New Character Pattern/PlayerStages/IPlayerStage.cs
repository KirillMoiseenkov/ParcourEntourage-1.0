using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStage
{
    void execute();
    void addTrick(TrickElement trick);
    void addTrickRange(Dictionary<string, TrickElement> tricks);
    void addElementToQueue(TrickElement trick);
    TrickElement getElementFromTrickDictionary(string trickName);
    //void setTrick(TrickElement trick);
}
