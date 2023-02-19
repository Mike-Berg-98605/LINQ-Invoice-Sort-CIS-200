/*Student ID: 1416810
 * Lab1
 * Due: 9/22/2021
 * CIS 200-50
 * This program sorts a list of invoices using LINQ
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Lab1
{
    public class LinqTest
    {
        public static void Main(string[] args)
        {
            int min_Total = 200, max_Total = 500; //sets the min and max for the invoice totals

            // initialize array of invoices
            Invoice[] invoices = { 
                new Invoice( 83, "Electric sander", 7, 57.98M ), 
                new Invoice( 24, "Power saw", 18, 99.99M ), 
                new Invoice( 7, "Sledge hammer", 11, 21.5M ), 
                new Invoice( 77, "Hammer", 76, 11.99M ), 
                new Invoice( 39, "Lawn mower", 3, 79.5M ), 
                new Invoice( 68, "Screwdriver", 106, 6.99M ), 
                new Invoice( 56, "Jig saw", 21, 11M ), 
                new Invoice( 3, "Wrench", 34, 7.5M ) };
                       

            // Display original array
            WriteLine("Original Invoice Data\n");
            WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            WriteLine("----- -------------------- ----- ------");

            foreach (Invoice inv in invoices)
                WriteLine(inv);
            WriteLine();

            //Sorts the desciption of parts alphabetically
            var PartDescriptionSort = //stores the part descriptions in ascending order
                from i in invoices 
                //precondition: none
                //postcondition: list is sorted ascending alphabetically
                orderby i.PartDescription
                select i.PartDescription;

            //Display part descriptions
            WriteLine("Invoice Part Descriptions:\n");
            //iterates through PartDescriptionSort
            foreach (var PartD in PartDescriptionSort) 
                WriteLine(PartD);

            //Sorts Prices in ascending order
            var PriceSort = //stores the prices in ascending order
                from i in invoices
                //precondition: none
                //postcondition: price is sorted ascending
                orderby i.Price
                select i.Price;

            WriteLine();
            //Displays prices
            WriteLine("Invoice Prices:\n");
            //iterates through PriceSort
            foreach (var Price in PriceSort) 
                WriteLine($"{Price:C}");

            WriteLine();
            //Sorts parts by quantity ascending with part description
            var PartDQuantSort = //stores parts and quantity
                from i in invoices
                //precondition: none
                //postcondition: parts are sorted by quantity
                orderby i.Quantity
                select new { i.Quantity, i.PartDescription };

            WriteLine();
            //displays quantity with part description
            WriteLine("Parts sorted by Quantity:\n");
            // iterates through PartDQuantSort
            foreach (var Quant in PartDQuantSort) 
                WriteLine($"{Quant.Quantity} {Quant.PartDescription}");

            WriteLine();

            //displays invoices between 200 and 400 along with part description
            var PartDAndInv = //stores invoice total and part
                from i in invoices
                //precondition: none
                //postcondition: total is assigned value
                let total = i.Quantity * i.Price 
                //precondition: none
                //postcondition: total is sorted ascending
                orderby total
                //precondition: Min >= 200 Max <= 500
                //postconditon: list of invoices totals between 200 and 500 created
                where (total >= min_Total) && (total <= max_Total) 
                select new { Total = total, i.PartDescription };

            WriteLine();
            //Displays invoice total and part description
            WriteLine("Invoice:    Part:\n");
            //iterates through PartDAndInv
            foreach (var inv in PartDAndInv)
                WriteLine($"{inv.Total:C}     {inv.PartDescription}");            
                       
           
    }
        
    }
}
