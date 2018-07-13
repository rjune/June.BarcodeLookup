using System;
using System.Collections.Generic;
using System.Text;

namespace June.BarcodeLookup.Data
{
    public class Product
    {
        public string barcode_number { get; set; }
        public string barcode_type { get; set; }
        public string product_name { get; set; }
        /// <summary>
        /// Manufacturer Part Number
        /// </summary>
        public string mpn { get; set; }
        public string model { get; set; }
        public string asin { get; set; }
        public string title { get; set; }
        /// <summary>
        /// https://www.google.com/basepages/producttype/taxonomy-with-ids.en-US.txt
        /// </summary>
        public string category { get; set; }
        public string manufacturer { get; set; }
        public string brand { get; set; }
        public string label { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public string artist { get; set; }
        public string actor { get; set; }
        public string director { get; set; }
        public string studio { get; set; }
        public string genre { get; set; }
        public string audience_rating { get; set; }
        public string ingredients { get; set; }
        public string nutrition_facts { get; set; }
        public string color { get; set; }
        public string format { get; set; }
        public string package_quantity { get; set; }
        public string size { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string release_date { get; set; }
        public string description { get; set; }
        public List<string> features { get; set; }
        public List<string> images
        {
            get { return _images ?? (_images = new List<string>()); }
            set { _images = value; }
        }
        public List<Store> stores 
        {
            get { return _stores ?? (_stores = new List<Store>()); }
            set { _stores = value; }
        }
        public List<string> reviews 
        {
            get { return _reviews ?? (_reviews = new List<string>()); }
            set { _reviews = value; }
        }

        private List<string> _images;
        private List<Store> _stores;
        private List<string> _reviews; 
    }
}
