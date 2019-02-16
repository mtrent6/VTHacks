using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Restaurant
{
    public class Restaurant
    {
        public string Name { get; set; }
        public int NumReviews { get; set; }
        public string Price { get; set; }
        public double Rating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Restaurant(string inName, int inNumReviews, string inPrice, double inRating, double inLatitude, double inLongitude)
        {
            Name = inName;
            NumReviews = inNumReviews;
            Price = inPrice;
            Rating = inRating;
            Latitude = inLatitude;
            Longitude = inLongitude;
        }
    }
}
