using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class UnityCoord: MonoBehaviour
{

	[SerializeField]
	AbstractMap _map;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			Vector2d latLong = new Vector2d(33.9425, -118.41);
			Vector2d latLong1 = new Vector2d(33.944, -118.407056);
			Vector2d latLong2 = new Vector2d(33.9434, -118.409056);
			Vector2d latLong3 = new Vector2d(33.95, -118.406056);
			Vector2d latLong4 = new Vector2d(33.9382, -118.42056);

			Debug.Log("Map Center : " + _map.CenterMercator.ToString());
			Debug.Log("Map World Relative Scale : " + _map.WorldRelativeScale.ToString());
			Debug.Log("World Position : " + Conversions.GeoToWorldPosition(latLong, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz());
			//GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);

			//go.transform.localPosition = Conversions.GeoToWorldPosition(latLong, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			//go.transform.MoveToGeocoordinate (10, 10, new Vector2d (33.9425, -118.408056), .008176666f);
			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			//go.transform.position = Conversions.GeoToWorldGlobePosition(36.59381, -121.87692, 5);
			go.transform.localPosition = Conversions.GeoToWorldPosition(latLong, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			GameObject go1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			//go1.transform.position = Conversions.GeoToWorldGlobePosition(36.59337, -121.87730, 5);
			go1.transform.localPosition = Conversions.GeoToWorldPosition(latLong1, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			GameObject go2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			//go2.transform.position = Conversions.GeoToWorldGlobePosition(36.59381, -121.87692, 5);
			go2.transform.localPosition = Conversions.GeoToWorldPosition(latLong2, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			GameObject go3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			//go3.transform.position = Conversions.GeoToWorldGlobePosition(41.32404, -105.57775, 5);
			go3.transform.localPosition = Conversions.GeoToWorldPosition(latLong3, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			GameObject go4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			//go3.transform.position = Conversions.GeoToWorldGlobePosition(41.32404, -105.57775, 5);
			go4.transform.localPosition = Conversions.GeoToWorldPosition(latLong4, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			

		}
	}




}