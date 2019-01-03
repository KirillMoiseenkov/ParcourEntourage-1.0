using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private CharacterMain characterMain;
    private void OnTriggerEnter(Collider other)
    {
        characterMain.score++;
        GameObject.Destroy(this.gameObject);
    }
}
