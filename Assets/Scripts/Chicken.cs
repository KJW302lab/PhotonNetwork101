using UnityEngine;

public class Chicken : MonoBehaviour
{
    public static Chicken Load(Vector3 position, Quaternion rotation)
    {
        var prefab = Resources.Load<GameObject>("Chicken");
        var chicken = Instantiate(prefab, position, rotation).GetComponent<Chicken>();
        return chicken;
    }
}