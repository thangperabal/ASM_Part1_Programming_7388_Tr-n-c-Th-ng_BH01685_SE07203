using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_PROGRAMMING_SUM2024
{
    internal class WaterBill_Program
    {
        static void Main(string[] args)
        {
            Console.Write("Customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Last month’s water meter readings: ");
            double lastMonthWaterMeterReadings = Convert.ToDouble(Console.ReadLine());

            Console.Write("This month’s water meter readings: ");
            double thisMonthWaterMeterReadings = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter customer type (household, administrative, production, business): ");
            string customerType = Console.ReadLine();

            double numberOfPeople = 0;
            if (customerType == "household")
            {
                Console.Write("Enter the number of people: ");
                numberOfPeople = Convert.ToDouble(Console.ReadLine());
            }

            double waterConsumed = thisMonthWaterMeterReadings - lastMonthWaterMeterReadings;
            double totalBill = CalculateTotalWaterBill(customerType, waterConsumed, numberOfPeople);

            // Export billing information
            Console.WriteLine("Water bill:");
            Console.WriteLine($"Customer name: {customerName}");
            Console.WriteLine($"Last month’s water meter readings: {lastMonthWaterMeterReadings}");
            Console.WriteLine($"This month’s water meter readings: {thisMonthWaterMeterReadings}");
            Console.WriteLine($"Water consumed: {waterConsumed} m3");
            Console.WriteLine($"Total water fee (with VAT): {totalBill} VND");
        }

        static double CalculatingWaterPrices(string customerType, double waterConsumed, double numberOfPeople)
        {
            double price = 0;

            if (customerType == "household")
            {
                double waterAmountPerPerson = waterConsumed / numberOfPeople;
                if (waterAmountPerPerson <= 10)
                {
                    price = 5.973 * waterConsumed;
                }
                else if (waterAmountPerPerson <= 20)
                {
                    price = 7.052 * waterConsumed;
                }
                else if (waterAmountPerPerson <= 30)
                {
                    price = 8.699 * waterConsumed;
                }
                else
                {
                    price = 15.929 * waterConsumed;
                }
            }
            else if (customerType == "administrative")
            {
                price = 9.955 * waterConsumed;
            }
            else if (customerType == "production")
            {
                price = 11.615 * waterConsumed;
            }
            else if (customerType == "business")
            {
                price = 22.068 * waterConsumed;
            }

            return price;
        }

        static double CalculateTotalWaterBill(string customerType, double waterConsumed, double numberOfPeople)
        {
            double price = CalculatingWaterPrices(customerType, waterConsumed, numberOfPeople);

            double environmentalProtectionFee = price * 0.10;
            double totalInvoiceWithoutVAT = price + environmentalProtectionFee;
            double VAT = 0.10 * totalInvoiceWithoutVAT;
            double totalBillVAT = totalInvoiceWithoutVAT + VAT;

            return totalBillVAT;
        }
    }
}