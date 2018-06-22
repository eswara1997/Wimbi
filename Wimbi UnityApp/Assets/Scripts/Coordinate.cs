using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



    [System.Serializable]
    public class Coordinate
    {
        /// <summary>
        ///     Initializes a new instance of the GeoCoordinate class from latitude, longitude, and altitude data.
        /// </summary>
        /// <param name="x">x value. May be negative or positive.</param>
        /// <param name="y">y value. may be negative or positive. </param>
        /// <param name="z">The altitude in meters. May be negative, 0, positive</param>
       
        public Coordinate(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// empty coordinate
        /// </summary>
        public Coordinate()
                : this(float.NaN, float.NaN, float.NaN)
            {
        }


        public float X
        {
            get; set; 
        }

        public float Y
        {
            get; set;
        }

        public float Z
        {
            get; set;
        }

        /// <summary>
        /// Calculates distance between two coordinates
        /// <param name="other"> represents the coordinate to get distance to</param>
        /// </summary>
        /// <param name="other"></param>
        public double GetDistanceTo(Coordinate other)
        {
            float xDistance = this.X - other.X;
            float yDistance = this.Y - other.Y;
            float zDistance = this.Z - other.Z;

            float sumSquared = xDistance * xDistance + yDistance * yDistance + zDistance*zDistance;

            double distance = Math.Sqrt(System.Convert.ToDouble(sumSquared));
            return distance;

        }


        /// <summary>
        ///     Determines whether two Coordinate objects correspond to different locations.
        /// </summary>
        /// <returns>
        ///     true, if the GeoCoordinate objects are determined to be different; otherwise, false.
        /// </returns>
        /// <param name="left">The first Coordinate to compare.</param>
        /// <param name="right">The second Coordinate to compare.</param>
        public static bool operator !=(Coordinate left, Coordinate right)
        {
            return !(left == right);
        }

        /// <summary>
        ///     Determines whether two Coordinate objects refer to the same location.
        /// </summary>
        /// <returns>
        ///     true, if the Coordinate objects are determined to be equivalent; otherwise, false.
        /// </returns>
        /// <param name="left">The first Coordinate to compare.</param>
        /// <param name="right">The second Coordinate to compare.</param>
        public static bool operator ==(Coordinate left, Coordinate right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        /// <summary>
        ///     Determines if the GeoCoordinate object is equivalent to the parameter, based solely on latitude and longitude.
        /// </summary>
        /// <returns>
        ///     true if the GeoCoordinate objects are equal; otherwise, false.
        /// </returns>
        /// <param name="other">The GeoCoordinate object to compare to the calling object.</param>
        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(other, null))
                return false;

            var num = X;

            if (!num.Equals(other.X))
                return false;

            num = this.Y;

            if (!num.Equals(other.Y))
                return false;

            num = this.Z;
            return num.Equals(other.Z);
        }


        ///     Serves as a hash function for the Coordinate.
        /// </summary>
        /// <returns>
        ///     A hash code for the current Coordinate.
        /// </returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }







    }

    

    
    

