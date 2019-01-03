using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MyDir : MonoBehaviour {

	[System.Serializable]
	public struct KV
	{
		public Queue<Data.point> Key;

		public Queue<string> Value;
		//public List<Data.point> Key;
		//public List<string> Value;
	}
	public KV kv = new KV();


	public MyDir(){
		kv.Key = new Queue<Data.point> ();
		 kv.Value = new Queue<string> ();

	}

	public void Push_Element_MyDir(Data.point point , string action)
	{
		kv.Key.Enqueue(point);
		kv.Value.Enqueue(action);
		//Key.Enqueue (point);
		//Value.Enqueue(action);

	}

	public Data.point Return_key_MyDir()
	{
		return kv.Key.Peek();

	}
	public string Return_Value_MyDir()
	{
		
		return kv.Value.Peek();

	}

	public void Delete()
	{
		kv.Key.Dequeue ();
		kv.Value.Dequeue ();
	}


}