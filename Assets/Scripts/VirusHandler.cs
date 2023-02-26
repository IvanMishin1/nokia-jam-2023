using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusHandler : MonoBehaviour
{
    public List<VirusEffect> availableEffects;
    public List<VirusEffect> activeEffects;
    // Start is called before the first frame update
    void Start()
    {
        availableEffects.AddRange(transform.Find("VirusEffects").GetComponents<VirusEffect>());
    }

    public void Infect()
    {
        int index = Random.Range(0, availableEffects.Count);
        availableEffects[index].Infect();
        activeEffects.Add(availableEffects[index]);
        availableEffects.RemoveAt(index);
    }

    // Update is called once per frame
    public void RevertAll()
    {
        while(activeEffects.Count > 0)
        {
            availableEffects.Add(activeEffects[0]);
            activeEffects[0].Revert();
            activeEffects.RemoveAt(0);
        }
    }
}
