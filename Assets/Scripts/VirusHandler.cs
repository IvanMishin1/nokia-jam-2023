using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusHandler : MonoBehaviour
{
    public List<VirusEffect> virusEffects;
    // Start is called before the first frame update
    void Start()
    {
        virusEffects.AddRange(transform.Find("VirusEffects").GetComponents<VirusEffect>());
    }

    public void Infect()
    {
        int index = Random.Range(0, virusEffects.Count);
        virusEffects[index].Infect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
