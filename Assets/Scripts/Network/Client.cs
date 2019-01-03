using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;

public class Client : MonoBehaviour {
	internal Boolean socketReady = false;
	private TcpClient mySocket;
	private NetworkStream theStream;
	private StreamWriter theWriter;
	private StreamReader theReader;
	private String Host = "localhost";
	private Int32 Port = 4224;
	private String Con;
		
	 public void setupSocket() {
	
		try {
			mySocket = new TcpClient(Host, Port);
			theStream = mySocket.GetStream();
			theWriter = new StreamWriter(theStream);
			theReader = new StreamReader(theStream);
			socketReady = true;
			theWriter.Write("Name of Map");
		}
		catch (Exception e) {
			Debug.Log("Socket error: " + e);
		}
	}
	public void writeSocket(string theLine) {
		if (!socketReady)
			return;
		String foo = theLine + "\r\n";
		theWriter.Write(foo);
		theWriter.Flush();
	}
	public String readSocket() {
		if (!socketReady)
			return "";
		if (theStream.DataAvailable)
			return theReader.ReadLine();
		return "";
	}
	public void closeSocket() {
		if (!socketReady)
			return;
		theWriter.Close();
		theReader.Close();
		mySocket.Close();
		socketReady = false;
	}
	void Start()
	{
		setupSocket ();
	
	}
	void Update () {
			Con = Convert.ToString (this.transform.position.x) + " " + Convert.ToString(this.transform.position.y);
			writeSocket (Con);
			print(readSocket ());	
	}

}
