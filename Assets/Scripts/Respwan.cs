using UnityEngine;
using System.Collections;

public class Respwan : MonoBehaviour {
    Employee redEmployee;
    Employee blueEmployee;

    public GameObject PRed;
    public GameObject PBlue;

    public Material RedMat;
    public Material BlueMat;
    public GameObject Recliner;

    const string redTag = "PRed";
    const string blueTag = "PBlue";

    const float yEmployeeReset = 3f;
    const float zRedEmployeeReset = 3.5f;
    const float zBlueEmployeeReset = -0.5f;
    const float yReclinerReset = -2.9f;

    void Start() {
        redEmployee = PRed.GetComponent<Employee>();
        blueEmployee = PBlue.GetComponent<Employee>();
    }

    void Update() {
        if (redEmployee.isDead) {
            SpawnRecliner(zRedReclinerReset, redTag, RedMat);
            SpawnEmployee(redEmployee, zRedEmployeeReset);
        }
            
        if (blueEmployee.isDead) {
            SpawnRecliner(zBlueReclinerReset, blueTag, BlueMat);
            SpawnEmployee(blueEmployee, zBlueEmployeeReset);
        }
    }

    void SpawnEmployee(Employee employee, float zEmployeeReset) {
        employee.Live();
        employee.tPosition = new Vector3(
            Camera.main.transform.position.x, yEmployeeReset, zEmployeeReset);
    }

    void SpawnRecliner(float zReclinerReset, string tag, Material color) {
        GameObject spawnRecliner = Instantiate(Recliner);

        foreach (Renderer rend in spawnRecliner.GetComponentsInChildren<Renderer>())
            rend.material = color;

        spawnRecliner.tag = tag;
        spawnRecliner.transform.position = new Vector3(
            Camera.main.transform.position.x, yReclinerReset, zReclinerReset);
    }
}
