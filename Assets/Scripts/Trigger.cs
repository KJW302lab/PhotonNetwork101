using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void Start()
    {
        Chicken.Load(Vector3.zero, Quaternion.identity);
    }
}