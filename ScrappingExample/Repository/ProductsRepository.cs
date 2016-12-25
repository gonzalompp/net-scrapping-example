using HtmlAgilityPack;
using ScrappingExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ScrappingExample.Repository
{
    public class ProductsRepository
    {
        //Returns the product wanted
        public static List<Products> GetProductList()
        {

            HtmlWeb website = new HtmlWeb();

            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;

            HtmlDocument Doc = website.Load("http://localhost:6744/");

            //get the first node that fit the "table" type that has a "product-list" class attribute 
            var tabla = Doc.DocumentNode.Descendants("table").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("product-list")).First();

            //then, get all the tr nodes of the first tbody node (from the table variablet obtained in the last Linq query)
            var rows = tabla.Descendants("tbody").First().Descendants("tr");

            //create the product list
            List<Products> prod_list = new List<Products>();

            //go over each tr
            foreach(var tr in rows)
            {
                //get the list of td nodes from the tr
                var fields = tr.Descendants("td");

                //generates the URL variable from the fifth td element. Then, search for the first attribute with the name "href" and gets the value.
                string url = fields.ElementAt(5).FirstChild.Attributes.Where(e => e.Name.Contains("href")).First().Value;

                //add a new product with the content of every td inner text
                prod_list.Add(new Products()
                {
                    ID = Convert.ToInt16(fields.ElementAt(0).InnerText),
                    BrandName = fields.ElementAt(1).InnerText,
                    Name = fields.ElementAt(2).InnerText,
                    Price = Convert.ToInt16(fields.ElementAt(3).InnerText.Replace("$","")), //cleans the price, replacing the $ for an empty space, so it can be converted to a Int value
                    Quantiy = Convert.ToInt16(fields.ElementAt(4).InnerText),
                });

            }

            return prod_list;
        }
    }
}