using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class IPTracker : MonoBehaviour
{
    IPHostEntry _ipEntry;
    private List<int> _splitNumbers = new List<int>();
    private string _ip;
    private Transform _wall;
    [SerializeField]
    private Text _text;

    // Use this for initialization
    void Start()
    {
        _wall = this.gameObject.transform;
        Debug.Log(GetHostName());
        Debug.Log(GetIPAdress());
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log(ChopIP()[i]);
            _splitNumbers.Add(int.Parse(ChopIP()[i]));
            Debug.Log(_splitNumbers[i]);
        }

        _wall.localScale = new Vector3(_splitNumbers[0], _splitNumbers[1], _splitNumbers[2]);
        _text.text = "The wall just got " + _splitNumbers[0] + " ft longer " + _splitNumbers[1] + " ft taller and " + _splitNumbers[2] + " ft wider and blocked " + _splitNumbers[3] + " people today" + "\n\n" + "Total cost of the Wall: $" + _ip;  
    }

    string GetHostName()
    {
        return Dns.GetHostName();
    }

    private string GetIPAdress()
    {
        _ipEntry = Dns.GetHostEntry(GetHostName());

        foreach (IPAddress ip in _ipEntry.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                _ip = ip.ToString();
                return _ip;
            }
        }
        throw new Exception("Local IP Address Not Found!");
    }

    private string[] ChopIP()
    {
        return _ip.Split('.');
    }
}
