using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionController : MonoBehaviour
{
    public string FactionName;
    public string FactionCallsign;
    public string factionDigraph; // two letter short version of callsign for brevity
    [SerializeField]
    private AnvilHuman FactionLead;
    public List<AnvilRoute> factionRouteList;
    public List<AnvilRoute> allWayPoints;
    public List<AnvilAgent> factionAgentList;
    public List<AnvilHuman> factionHumanList;
    public List<AnvilWayPoint> allWayPointsList;


    // Use this for initialization
    void Awake()
    {
        gameObject.name = FactionName;
    }
    void Start()
    {
        factionRouteList = new List<AnvilRoute>();
        AnvilWayPoint waypointA0 = new AnvilWayPoint(36.58386, -121.83619, 200, "KM01");
        AnvilWayPoint waypointA1 = new AnvilWayPoint(36.58951, -121.85216, 157, "KM02");
        AnvilWayPoint waypointA2 = new AnvilWayPoint(36.58951, -121.85216, 157, "KM03");
        AnvilWayPoint waypointB0 = new AnvilWayPoint(36.58951, -121.85216, 157, "KM04");
        AnvilWayPoint waypointB1 = new AnvilWayPoint(36.58951, -121.85216, 157, "KM05");
        AnvilWayPoint waypointB2 = new AnvilWayPoint(36.58951, -121.85216, 157, "KM06");


        List<AnvilWayPoint> routeAList = new List<AnvilWayPoint> { waypointA0, waypointA1, waypointA2 };
        List<AnvilWayPoint> routeBList = new List<AnvilWayPoint> { waypointB0, waypointB1, waypointB2 };
        List<AnvilWayPoint> routeCList = new List<AnvilWayPoint> { waypointB2, waypointB1, waypointA1 };
        List<AnvilWayPoint> wayPointList = new List<AnvilWayPoint>();
        wayPointList.Add(waypointA0);
        wayPointList.Add(waypointA1);
        wayPointList.Add(waypointA2);
        wayPointList.Add(waypointB0);
        wayPointList.Add(waypointB1);
        wayPointList.Add(waypointB2);

        AnvilRoute routeA = new AnvilRoute("routeA", routeAList);
        AnvilRoute routeB = new AnvilRoute("routeB", routeBList);
        AnvilRoute routeC = new AnvilRoute("routeC", routeCList);
        AnvilRoute allRoutes = new AnvilRoute("allPoints", wayPointList);//this is a workaround to show all waypoints from all routes.
        allWayPointsList = wayPointList;

        factionRouteList = new List<AnvilRoute>();
        factionRouteList.Add(allRoutes);
        factionRouteList.Add(routeA);
        factionRouteList.Add(routeB);
        factionRouteList.Add(routeC);

        RefreshFaction();

    }

    public void RefreshFaction()
    {
        factionAgentList = new List<AnvilAgent>(gameObject.GetComponentsInChildren<AnvilAgent>());
        FindSeniorAgentInFaction();
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void FindSeniorAgentInFaction()
    {
        AnvilHuman highestRankingHuman;
        List<AnvilAgent> justHumans = new List<AnvilAgent>();
        foreach (AnvilAgent thisAgent in factionAgentList)
        {
            if (thisAgent is AnvilHuman)
            {
                justHumans.Add(thisAgent);
            }
        }
        highestRankingHuman = justHumans[0] as AnvilHuman;

        foreach (AnvilHuman thisHuman in justHumans)
        {
            if (thisHuman.getRankIndex() > highestRankingHuman.getRankIndex())
            {
                highestRankingHuman = thisHuman;
            }
        }
        FactionLead = highestRankingHuman;
    }
    public string GetDigraph()
    {
        return factionDigraph; 
            }
}
    
