using System;
using System.Collections;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    Portal[] portals;

    void Awake () {
        UpdatePortalList();
    }

    public void UpdatePortalList()
    {
        portals = FindObjectsOfType<Portal>();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].PrePortalRender();
            }
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].Render();
            }
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].PostPortalRender();
            }
        }
    }
}