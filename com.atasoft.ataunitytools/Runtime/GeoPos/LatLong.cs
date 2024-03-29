﻿using System;
using UnityEngine;

namespace AtaUnityTools.GeoPos
{
    /// <summary>
    /// Represent an angle as Latitude/Longitude.
    /// </summary>
    public class LatLong
    {
        private double _latRads;

        /// <summary>
        /// Latitude in Radians.
        /// </summary>
        public double LatRads {
            get => _latRads;
            set
            {
                if (value < -Math.PI / 2 || value > Math.PI / 2)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _latRads = value;
            }
        }

        private double _longRads;

        /// <summary>
        /// Longitude in Radians.
        /// </summary>
        public double LongRads
        {
            get => _longRads;
            set
            {
                if (value < -Math.PI || value > Math.PI)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _longRads = value;
            }
        }

        /// <summary>
        /// Latitude in Degress.
        /// </summary>
        public double LatDeg
        {
            get => _latRads * 180d / Math.PI;
            set
            {
                LatRads = value * Math.PI / 180d;
            }
        }

        /// <summary>
        /// Longitude in Degress.
        /// </summary>
        public double LongDeg
        {
            get => _longRads * 180d / Math.PI;
            set
            {
                LongRads = value * Math.PI / 180d;
            }
        }

        /// <summary>
        /// Cardinal direction of latitude. (N or S)
        /// </summary>
        public string LatCardinal => (LatDeg < 0 ? "S" : "N");

        /// <summary>
        /// Cardinal direction of longitude. (E of W)
        /// </summary>
        public string LongCardinal => (LongDeg < 0 ? "W" : "E");

        public LatLong() { }

        public LatLong(double latDegs, double longDegs)
        {
            LatDeg = latDegs;
            LongDeg = longDegs;
        }

        /// <summary>
        /// ex. N12W123
        /// </summary>
        public string WholeNLatELong => $"{LatCardinal}{Math.Abs((int)LatDeg).ToString("D2")}{LongCardinal}{Mathf.Abs((int)LongDeg).ToString("D3")}";

        /// <summary>
        /// This LatLong represented as a Unity Quaternion.
        /// </summary>
        /// <returns></returns>
        public Quaternion ToQuaternion()
        {
            return Quaternion.Euler((float)-LatRads * Mathf.Rad2Deg, (float)-LongRads * Mathf.Rad2Deg, 0);
        }

        /// <summary>
        /// Get the cartesian position on Earth at an altitude relative to sea level.
        /// </summary>
        public Vector3 PosAtAltitude(float altitudeASL)
        {
            var radius = GeoPosition.SeaLevelAtLatLong(this);

            return ToQuaternion() * Vector3.forward * (float)(radius + altitudeASL);
        }
    }
}
