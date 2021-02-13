using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCreateConnect : MonoBehaviour
{

    /// <summary>
    /// connector - хранит объект ConnectObjectrs.  
    /// Получать в методе start или в подобных
    /// </summary>
    public ConnectObjects connector;

    /// <summary>
    /// Перед включении, ищёт объект "ConnectObjects" и записывает его компонент "ConnectObjects"  в connect
    /// </summary>
    private void OnEnable()
    {
        connector = GameObject.Find("ConnectObjects").GetComponent<ConnectObjects>();
    }

    /// <summary>
    /// Метод для старта подключения плюса
    /// </summary>
    public void StartConnectPlus()
    {


        connector.IsConnectToPlus = true;
        connector.FirstObject = gameObject;
        connector.ConnectionInProgress = true;
    }
        

    /// <summary>
    /// Метод для старта подключения минуса
    /// </summary>
    public void StartConnectMinus()
    {
        connector.IsConnectToPlus = false;
        connector.FirstObject = gameObject;
        connector.ConnectionInProgress = true;

    }
}
