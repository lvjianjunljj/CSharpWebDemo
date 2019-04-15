﻿using CSharpWebAPIApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpWebAPIApplication.Controllers
{
    [RoutePrefix("api/productss")]
    public class ProductsController : BaseController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            products = new Product[]
            {
                new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
            };
        }
        [Route("all/1")]
        public IEnumerable<string> GetProducts()
        {
            string[] res = new string[] { "1", "2" };
            return res;
            //return products;
        }

        [Route("all/2/{id}")]
        public IEnumerable<string> GetProducts(int id)
        {
            string[] res = new string[] { "1", "2", id + "_" };
            return res;
            //return products;
        }

        // http://localhost:8771/api/products
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        // http://localhost:8771/api/products/1
        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }
        // http://localhost:8771/api/products/?category=Groceries
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where(
                (p) => string.Equals(p.Category, category,
                    StringComparison.OrdinalIgnoreCase));
        }

        [Route("testxml")]
        public HttpResponseMessage GetTestXml()
        {
            Product[] products = new Product[]
            {
                new Product { Name = "Tomato Soup", Category = "Groceries", Price = 1 },
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
            };
            string xmlString = ConvertObjectToXMLString(products);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(xmlString, Encoding.UTF8, "application/xml") };
            return result;
        }

        [Route("testjson")]
        public HttpResponseMessage GetTestJson1()
        {
            Product[] products = new Product[]
            {
                new Product { Name = "Tomato Soup", Category = "Groceries", Price = 1 },
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
            };
            string jsonString = JsonConvert.SerializeObject(products);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(jsonString, Encoding.UTF8, "application/json") };
            return result;
        }

        // The two method for converting object to xml string
        private string ConvertObjectToXMLString(object classObject)
        {
            string xmlString = null;
            XmlSerializer xmlSerializer = new XmlSerializer(classObject.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, classObject);
                memoryStream.Position = 0;
                xmlString = new StreamReader(memoryStream).ReadToEnd();
            }
            return xmlString;
        }

        private string ConvertObjectToXMLString2(object value)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            XmlSerializer serial = new XmlSerializer(value.GetType());
            serial.Serialize(writer, value);
            return sb.ToString();
        }
    }
}
