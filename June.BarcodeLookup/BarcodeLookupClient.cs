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
        Uri _uri;
        string _apiKey;
        public BarcodeLookupClient()
        {
            _uri = new Uri("https://api.barcodelookup.com/v2/products");
            //_uri = new Uri("https://www.barcodelookup.com/");
            _apiKey = "gm3z6rvp0i2k0i7qujko1gtqbz4fpx";
        }

        public Product Lookup(string barcode)
        {
            var wc = new WebClient();
            var uri = _uri.ToString() + string.Format("?key={0}&barcode={1}", _apiKey, barcode);
            var json = wc.DownloadString(_uri.ToString() + string.Format("?key={0}&barcode={1}", _apiKey, barcode));
            //json = "{\"products\":[{\"barcode_number\":\"051667894228\",\"barcode_type\":\"UPC\",\"barcode_formats\":\"UPC 051667894228, EAN 0051667894228\",\"mpn\":\"\",\"model\":\"\",\"asin\":\"\",\"product_name\":\"Kobalt 47pc Drill and Drive Bit Set -\",\"title\":\"\",\"category\":\"Hardware > Tools > Tool Sets > Hand Tool Sets\",\"manufacturer\":\"Kobalt\",\"brand\":\"Kobalt\",\"label\":\"\",\"author\":\"\",\"publisher\":\"\",\"artist\":\"\",\"actor\":\"\",\"director\":\"\",\"studio\":\"\",\"genre\":\"\",\"audience_rating\":\"\",\"ingredients\":\"\",\"nutrition_facts\":\"\",\"color\":\"\",\"format\":\"\",\"package_quantity\":\"\",\"size\":\"\",\"length\":\"\",\"width\":\"\",\"height\":\"\",\"weight\":\"\",\"release_date\":\"\",\"description\":\"Kobalt 47pc Drill and Drive Bit Set 2 -in-1 Connector accepts all hex shank accessories and 1 inch insert bits Titanium coating increases drilling speeds and extends tool life For use with standard and impact drill / drivers and compatible with the Kobalt 2 -in-1 Connector Split point penetrates on contact to reduce drill bit walking(1 / 8 -in and larger) 1 / 4 -in hex shank stops bit spin -out\",\"features\":[],\"images\":[\"https://images.barcodelookup.com/8920/89206503-1.jpg\"],\"stores\":[{\"store_name\":\"Jet.com\",\"store_price\":\"24.99\",\"product_url\":\"http://jet.com/product/detail/ef1b0a808c214adfb65e066ed424d9b3\",\"currency_code\":\"USD\",\"currency_symbol\":\"$\"}],\"reviews\":[]}]}";
            var data = JObject.Parse(json);
            var i = 0;
            var mapItem = data[JsonPropertyName.Products][i];
            var rval = new Product()
            {
                BarcodeNumber = mapItem[JsonPropertyName.BarcodeNumber].ToString(),
                BarcodeType = mapItem[JsonPropertyName.BarcodeType].ToString(),
                ProductName = mapItem[JsonPropertyName.ProductName].ToString(),
                Description = mapItem[JsonPropertyName.Description].ToString(),
                Manufacturer = mapItem[JsonPropertyName.Manufacturer].ToString(),
                Brand = mapItem[JsonPropertyName.Brand].ToString(),
                Images = mapItem[JsonPropertyName.Images].ToObject<List<string>>(),
            };

            return rval;
        }
    }
}
