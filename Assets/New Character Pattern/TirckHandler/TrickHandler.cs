using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrickHandler : MonoBehaviour
{
    private Queue<TrickElement> tricks;
    private TricksData data;

    public TrickHandler(TricksData data)
    {
        tricks = new Queue<TrickElement>();
        this.data = data;
    }

    public void addToQueue(TrickElement trick) => tricks.Enqueue(trick);

    public TrickElement getFromQueue()
    {
        if (tricks.Count > 0)
        {
            return tricks.Dequeue();
        }
        else return null;
    }
}
