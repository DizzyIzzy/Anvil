using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DotNetCoords;
using Mapbox.Map;
using Mapbox.Unity;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public static class ConversionTool1 {


	private static BasicMap _map;
    

    public static Vector3 WayPointToUnityVector3D2(AnvilWayPoint waypoint)
    {
        BasicMap _map = GameObject.Find("Map").GetComponent<BasicMap>();
        Vector2d outputV2 = Conversions.GeoToWorldPosition(waypoint.mLatitude, waypoint.mLongitude, _map.CenterMercator, _map.WorldRelativeScale);
        Vector3 outputV3 = new Vector3((float)outputV2.x,0, (float)outputV2.y);

        return outputV3;
    }
   

}
