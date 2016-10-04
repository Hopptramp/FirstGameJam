using UnityEngine;
using System.Collections;

public class DestroyChildren : MonoBehaviour
{
    public void DestroyTheChildren()
    {
        for(int i = 0; i <= transform.childCount -1; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
