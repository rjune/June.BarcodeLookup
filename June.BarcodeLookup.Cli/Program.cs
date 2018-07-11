using System;

namespace June.BarcodeLookup.Cli
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new BarcodeLookupClient();
            var data = client.Lookup("820909567981");
            Console.WriteLine(data.ProductName);
            Console.WriteLine(data.BarcodeType + " - " + data.BarcodeNumber);
            Console.WriteLine(data.Description);
            return;
        }
    }
}
