# Ata Unity Tools

A library of serialization and math helpers I've used in Unity projects.

## Installation

PackageManage->Add Git->`https://github.com/ataboo/ataunitytools.git#upm`

Make sure you're adding the `upm` branch as upm need package.json to be in the root path.

## Unity Binary Formatter

Unity objects don't have the serializable attribute.  This wraps System.IO.BinaryFormatter and implements surrogates for a few unity types so that your objects can be binary serialized.

```c#
[Serializable]
public class MyThing {
    public Vector3 Position {get; set;}

    public SomeType TheType {get; set;}
}

...

var formatter = new AtaUnityTools.UnitySerializer.UnityBinaryFormatter();
formatter.AddSurrogate<SomeType>(new SomeTypeSurrogate());
formatter.Serialize(someFileStream, myThing);

```

## LatLong/GeoPosition

Basic implementation of geo positional coordinates using latitude and longitude.

```c#
var latLong = new LatLong(-23, 114);
Debug.Log($"Coordinates: {latLong.WholeNLatElong}");

myObj.transform.position = latLong.ToQuaternion() * Vector3.forward * 10;
myObj.rotation = latLong.ToQuaternion();

// The scale of this is kind of ridiculous.
myObj.transform.position = latLong.PosAtAltitude(0);
```