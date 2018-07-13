using June.BarcodeLookup.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace June.BarcodeLookup
{
    public class BarcodeLookupClient
    {
        /// <summary>
        /// URI for the BarcodeLookup website
        /// </summary>
        private readonly Uri _uri;
        private readonly string _apiKey;

        /// <summary>
        /// Create a new client attached to <paramref name="apiKey"/>
        /// </summary>
        /// <param name="apiKey"></param>
        public BarcodeLookupClient(string apiKey)
        {
            _uri = new Uri("https://api.barcodelookup.com/v2/products");
            _apiKey = apiKey;
        }

        /// <summary>
        /// Get the product associated with <paramref name="barcode"/>.
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>Product or null if not found. </returns>
        public Product Lookup(string barcode)
        {
            var wc = new WebClient();
            var uri = _uri.ToString() + string.Format("?key={0}&barcode={1}", _apiKey, barcode);
            //var json = wc.DownloadString(_uri.ToString() + string.Format("?key={0}&barcode={1}", _apiKey, barcode));
            var json = GetJson();
            var data = JObject.Parse(json);
            var i = 0;
            var mapItem = data[JsonPropertyName.Products][i];
            var rval = mapItem.ToObject<Product>();
            //var rval = new Product()
            //{
            //    Actor = mapItem[JsonPropertyName.Actor].ToString(),
            //    Artist = mapItem[JsonPropertyName.Artist].ToString(),
            //    Asin = mapItem[JsonPropertyName.Asin].ToString(),
            //    AudienceRating = mapItem[JsonPropertyName.AudienceRating].ToString(),
            //    Author = mapItem[JsonPropertyName.Author].ToString(),
            //    barcode_number = mapItem[JsonPropertyName.BarcodeNumber].ToString(),
            //    BarcodeType = mapItem[JsonPropertyName.BarcodeType].ToString(),
            //    Brand = mapItem[JsonPropertyName.Brand].ToString(),
            //    Category = mapItem[JsonPropertyName.Category].ToString(),
            //    Color = mapItem[JsonPropertyName.Color].ToString(),
            //    Description = mapItem[JsonPropertyName.Description].ToString(),
            //    Director = mapItem[JsonPropertyName.Director].ToString(),
            //    Features = mapItem[JsonPropertyName.Features].ToString(),
            //    Format = mapItem[JsonPropertyName.Format].ToString(),
            //    Genre = mapItem[JsonPropertyName.Genre].ToString(),
            //    Height = mapItem[JsonPropertyName.Height].ToString(),
            //    Images = mapItem[JsonPropertyName.Images].ToObject<List<string>>(),
            //    Ingredients = mapItem[JsonPropertyName.Ingredients].ToString(),
            //    Label = mapItem[JsonPropertyName.Label].ToString(),
            //    Length = mapItem[JsonPropertyName.Length].ToString(),
            //    Manufacturer = mapItem[JsonPropertyName.Manufacturer].ToString(),
            //    Model = mapItem[JsonPropertyName.Model].ToString(),
            //    mpn = mapItem[JsonPropertyName.Mpn].ToString(),
            //    NutritionFacts = mapItem[JsonPropertyName.NutritionFacts].ToString(),
            //    PackageQuantity = mapItem[JsonPropertyName.PackageQuantity].ToString(),
            //    product_name = mapItem[JsonPropertyName.ProductName].ToString(),
            //    Publisher = mapItem[JsonPropertyName.Publisher].ToString(),
            //    ReleaseDate = mapItem[JsonPropertyName.ReleaseDate].ToString(),
            //    //Reviews = mapItem[JsonPropertyName.Reviews].ToObject<List<Review>>(),
            //    Size = mapItem[JsonPropertyName.Size].ToString(),
            //    Stores = mapItem[JsonPropertyName.Stores].ToObject<List<Store>>(),
            //    Studio = mapItem[JsonPropertyName.Studio].ToString(),
            //    Title = mapItem[JsonPropertyName.Title].ToString(),
            //    Weight = mapItem[JsonPropertyName.Weight].ToString(),
            //    Width = mapItem[JsonPropertyName.Width].ToString(),
            //};

            return rval;
        }

        private string GetJson()
        {
            return "{ \"products\": [ { \"barcode_number\":\"051667894228\", \"barcode_type\":\"UPC\" ,\"barcode_formats\":\"UPC 051667894228, EAN 0051667894228\", \"mpn\":\"\", \"model\":\"\", \"asin\":\"\" ,\"product_name\":\"Kobalt 47pc Drill and Drive Bit Set -\" ,\"title\":\"\", \"category\":\"Hardware > Tools > Tool Sets > Hand Tool Sets\", \"manufacturer\":\"Kobalt\", \"brand\":\"Kobalt\", \"label\":\"\", \"author\":\"\", \"publisher\":\"\", \"artist\":\"\", \"actor\":\"\", \"director\":\"\", \"studio\":\"\", \"genre\":\"\", \"audience_rating\":\"\", \"ingredients\":\"\", \"nutrition_facts\":\"\", \"color\":\"\", \"format\":\"\", \"package_quantity\":\"\", \"size\":\"\", \"length\":\"\", \"width\":\"\", \"height\":\"\", \"weight\":\"\", \"release_date\":\"\", \"description\":\"Kobalt 47pc Drill and Drive Bit Set 2-in-1 Connector accepts all hex shank accessories and 1 inch insert bits Titanium coating increases drilling speeds and extends tool life For use with standard and impact drill/drivers and compatible with the Kobalt 2-in-1 Connector Split point penetrates on contact to reduce drill bit walking (1/8-in and larger) 1/4-in hex shank stops bit spin-out\", \"features\":[], \"images\": [\"https://images.barcodelookup.com/8920/89206503-1.jpg\"], \"stores\": [ {\"store_name\":\"Jet.com\",\"store_price\":\"24.99\",\"product_url\":\"http://jet.com/product/detail/ef1b0a808c214adfb65e066ed424d9b3\",\"currency_code\":\"USD\",\"currency_symbol\":\"$\"} ], \"reviews\":[] } ] }";
        }
    }
}
