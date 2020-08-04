using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static GameObject GetClosestPlayer(Transform caller, GameObject[] players)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = caller.position;
        foreach (GameObject player in players)
        {
            float dist = Vector3.Distance(player.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = player;
                minDist = dist;
            }
        }
        return tMin;
    }
}
