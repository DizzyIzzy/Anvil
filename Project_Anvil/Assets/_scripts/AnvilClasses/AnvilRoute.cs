using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilRoute {
    public string mRouteName;
    public Color mRouteColor;
    public bool hasHardTimeConstraint;
    public List<AnvilWayPoint> routeWayPoints = new List<AnvilWayPoint>();

    public AnvilRoute (string routeName, List<AnvilWayPoint> wayPointList)
    {
        mRouteName = routeName;
        routeWayPoints = new List<AnvilWayPoint>(wayPointList);
    }

    public AnvilRoute(string routeName,    Color color, List<AnvilWayPoint> wayPointList)
    {
        mRouteName = routeName;
        routeWayPoints = new List<AnvilWayPoint>(wayPointList);
        mRouteColor = color;
    }

    public int Count()
    {
    int numberOfPoints = routeWayPoints.Count;
    return numberOfPoints;
    }

    public Color GetColor()
    {
        if (mRouteColor != null)
        {
            return mRouteColor;
        }
        else { return Color.white; }
    }

    public List<AnvilWayPoint> returnWayPointList()
    {
        return routeWayPoints;
    }

	public void addWaypoint(AnvilWayPoint wayPoint)
	{
		routeWayPoints.Add (wayPoint);
	}




}
