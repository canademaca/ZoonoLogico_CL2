using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;



public class InicioAnalytics : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();


        AnalyticsService.Instance.StartDataCollection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
