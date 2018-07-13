using System;

namespace June.BarcodeLookup.Cli
{
    public class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "gm3z6rvp0i2k0i7qujko1gtqbz4fpx";

            var client = new BarcodeLookupClient(apiKey);
            var data = client.Lookup("820909567981");
            Console.WriteLine(data.product_name);
            Console.WriteLine(data.barcode_type + " - " + data.barcode_number);
            Console.WriteLine(data.description);
            return;
        }
    }
}
