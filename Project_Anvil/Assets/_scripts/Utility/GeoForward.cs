using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Geocoding;
using System.Text;
using Mapbox.Json;
using Mapbox.Platform;
using Mapbox.Utils.JsonConverters;
using Mapbox.Utils;
using Mapbox.Unity;

public class GeoForward : MonoBehaviour
{

    public ForwardGeocodeResponse geoResponse;
    public ForwardGeocodeResource geoResource;


    ForwardGeocodeResource _resource;
    Vector2d _coordinate;
    public Vector2d Coordinate
    {
        get
        {
            return _coordinate;
        }
    }

    bool _hasResponse;
    public bool HasResponse
    {
        get
        {
            return _hasResponse;
        }
    }


    public ForwardGeocodeResponse Response { get; private set; }
    public event Action<ForwardGeocodeResponse> OnGeocoderResponse = delegate { };

    void Awake()
    {
        _resource = new ForwardGeocodeResource("");
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void HandleLocationInput(string searchString)
    {
        _hasResponse = false;
        if (!string.IsNullOrEmpty(searchString))
        {
            _resource.Query = searchString;
            MapboxAccess.Instance.Geocoder.Geocode(_resource, HandleGeocoderResponse);
        }
    }

    void HandleGeocoderResponse(ForwardGeocodeResponse res)
    {
        _hasResponse = true;
        if (null == res)
        {
            Debug.Log("no geocode response");
        }
        else if (null != res.Features && res.Features.Count > 0)
        {
            Debug.Log(res.Features[0].Center);
            var center = res.Features[0].Center;
            //_inputField.text = string.Format("{0},{1}", center.x, center.y);
            _coordinate = res.Features[0].Center;
        }
        Response = res;
        OnGeocoderResponse(res);
    }
}
