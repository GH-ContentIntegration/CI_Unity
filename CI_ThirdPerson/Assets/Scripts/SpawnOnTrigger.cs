using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnTrigger : MonoBehaviour
{
    [Tooltip("Folder inside 'Resources' to load prefabs from")]
    public string resourceFolder = "PrefabsToSpawn";

    [Tooltip("Set this to true if you want to only trigger once")]
    public bool triggerOnce = true;

    [Tooltip("List of props to spawn")]
    public GameObject[] props;

    private bool hasTriggered = false;

    private void Start()
    {
        // Load all prefabs from the specified Resources subfolder
        props = Resources.LoadAll<GameObject>(resourceFolder);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerOnce && hasTriggered)
            return;

        if (props.Length == 0)
        {
            Debug.LogWarning("Hey Gamehead, assign some prefabs!");
            return;
        }

        foreach (GameObject prefab in props)
        {
            if (prefab != null)
            {
                Instantiate(prefab);
            }
        }

        hasTriggered = true;
    }
}
