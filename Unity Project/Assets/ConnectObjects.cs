

using UnityEngine;
using UnityEngine.UI;

public class ConnectObjects : MonoBehaviour
{   /// <summary>
    /// ����, ������������,  ��� �� ������ ����������� ��������;                                  
    /// </summary>
    public bool ConnectionInProgress;

    /// <summary>
    /// ������ ���������� ���� GameObject � ������������ ��������.
    /// </summary>
    public GameObject FirstObject;

    /// <summary>
    ///  ����, ��� ��������, ��� �� ����������� � �����.
    /// </summary>
    public bool IsConnectToPlus;

    [SerializeField] private Text debugUIText;

    /// <summary>
    /// ������ ������� ������.
    /// </summary>
    private Camera camera;


    /// <summary>
    /// �������� �� ����� �������� ����� ������ � ���������� �������� � camera
    /// </summary>
    private void Awake()
    {
        camera = Camera.main;
    }

    /// <summary>
    ///  ������ ���� �������� ������
    /// </summary>
    private void Update()
    {
        CreateConnection();
    }

    /// <summary>
    /// ����� ��� �������� �����������.
    /// 
    /// ���� ��� �����������, ��:
    /// ��������� ���� �� ������ ������ ��� �����������, ���� ��� ��:
    /// ��������� ������ �� ������ ���, ���� �� ��:
    /// ��������� ��� �� ������� �������  � ��������� ��� (minus or plus) � ������� � ������� �� ����� 
    /// � ������� �������� ����� ���������.
    /// </summary>
    private void CreateConnection()
    {
        if (ConnectionInProgress)
        {   
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit2D hit2D = Physics2D.Raycast(GetPositionCursor(), Vector3.forward);

                switch (hit2D.collider.tag)
                {
                    case "Plus":

                        CreateConnectionPlus(hit2D.collider.gameObject);
                        SetDefaultVolums();
                        break;
                    case "Minus":
                        CreateConnectionMinus(hit2D.collider.gameObject);
                        SetDefaultVolums();
                        break;



                }
            }
        }
        
    }

    /// <summary>
    /// ������ ���������� � �����.
    /// </summary>
    /// <param name="hit">������ �������� ����.</param>
    private void CreateConnectionPlus(GameObject secondObject)
    {
       
        var ParrentSecondObject = secondObject.GetComponent<Kid>().GetParrent();
        var SecondObjectData = ParrentSecondObject.GetComponent<ObjectData>();
        var FirstObjectData = FirstObject.GetComponent<ObjectData>();

        if (!SecondObjectData.TryAddObjectInArrayConnectedByPlus(FirstObject))
        {
            Debug.Log("Fail!");
        }
        if (!FirstObjectData.TryAddObjectInArrayConnectedByPlus(ParrentSecondObject))
        {
            Debug.Log("Fail!");
        }


        Debug.Log("Connect by plus done!");
    }

    /// <summary>
    ///  ������ ���������� � �����.
    /// </summary>
    /// <param name="hit">������ ��������� ����.</param>
    private void CreateConnectionMinus(GameObject secondObject)
    {
         
        var ParrentSecondObject = secondObject.gameObject.GetComponent<Kid>().GetParrent();
        var SecondObjectData = ParrentSecondObject.GetComponent<ObjectData>();
        var FirstObjectData = FirstObject.GetComponent<ObjectData>();

        if (!SecondObjectData.TryAddObjectInArrayConnectedByMinus(FirstObject))
        {
            Debug.Log("Fail!");
        }
        if (!FirstObjectData.TryAddObjectInArrayConnectedByMinus(ParrentSecondObject))
        {
            Debug.Log("Fail!");
        }

        

        Debug.Log("Connect by Minus done!");
    }

    /// <summary>
    /// �������� ���������� �������.
    /// </summary>
    /// <returns>����������� ���������� �������</returns>
    private Vector2 GetPositionCursor()
    {
        Vector2 cursor = Input.mousePosition;
        cursor = camera.ScreenToWorldPoint(cursor);
        return cursor;
    }


    /// <summary>
    /// ������������� ������� �������� �����.
    /// </summary>
    private void SetDefaultVolums()
    {
        FirstObject = null;
        ConnectionInProgress = false;
        IsConnectToPlus = false;
    }
}
