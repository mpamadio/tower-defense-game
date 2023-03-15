using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private Camera mainCamera;
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO buildingType;

    private void Awake()
    {
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        buildingType = buildingTypeList.list[0];
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Event e = Event.current;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    buildingType = buildingTypeList.list[0];
        //}
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    buildingType = buildingTypeList.list[1];
        //}
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    buildingType = buildingTypeList.list[2];
        //}
        Debug.Log("DETECTED KEY :" + e.keyCode);

        OnGUI();

    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            Debug.Log("Detected key code: " + e.keyCode);
            CheckButtons(e.keyCode);
        }
    }

    private void CheckButtons(KeyCode key)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            buildingType = buildingTypeList.list[0];
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            buildingType = buildingTypeList.list[1];
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            buildingType = buildingTypeList.list[2];
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
