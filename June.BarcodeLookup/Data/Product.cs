using System;
using System.Collections.Generic;
using System.Text;

namespace June.BarcodeLookup.Data
{
    public class Product
    {
        public string BarcodeNumber { get; set; }
        public string BarcodeType { get; set; }
        public string ProductName { get; set; }
        public string Mpn { get; set; }
        public string Model { get; set; }
        public string Asin { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// https://www.google.com/basepages/producttype/taxonomy-with-ids.en-US.txt
        /// </summary>
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Label { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Artist { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public string AudienceRating { get; set; }
        public string Ingredients { get; set; }
        public string NutritionFacts { get; set; }
        public string Color { get; set; }
        public string Format { get; set; }
        public string PackageQuantity { get; set; }
        public string Size { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public List<string> Images
        {
            get { return _images ?? (_images = new List<string>()); }
            set { _images = value; }
        }
        public List<object> Stores { get; set; }
        public List<object> Reviews { get; set; }

        private List<string> _images;
    }
}
