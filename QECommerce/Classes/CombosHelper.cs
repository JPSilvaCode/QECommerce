﻿using QECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QECommerce.Classes
{
    public class CombosHelper : IDisposable
    {
        private static QECommerceContext db = new QECommerceContext();

        public static List<Departaments> GetDepartaments()
        {
            var departaments = db.Departaments.ToList();
            departaments.Add(new Departaments
            {
                DepartamentsId = 0,
                Name = "[Selecione um Departamento]"
            });

            departaments = departaments.OrderBy(d => d.Name).ToList();

            return departaments;
        }

        public static List<City> GetCities(int departmentId)
        {
            var cities = db.Cities.Where(c => c.DepartamentsId == departmentId).ToList();
            cities.Add(new City
            {
                CityId = 0,
                Name = "[Selecione uma Cidade]"
            });

            cities = cities.OrderBy(d => d.Name).ToList();

            return cities;
        }

        public static List<Company> GetCompanies()
        {
            var companies = db.Companies.ToList();
            companies.Add(new Company
            {
                CompanyId = 0,
                Name = "[Selecione uma Companhia]"
            });

            companies = companies.OrderBy(d => d.Name).ToList();

            return companies;
        }

        public static List<WareHouse> GetWareHouse()
        {

            var comp = db.WareHouses.ToList();
            comp.Add(new WareHouse
            {
                CompanyId = 0,
                Name = "[ Selecione uma Armazém ]"
            });

            return comp = comp.OrderBy(c => c.Name).ToList();

        }

        public static List<Category> GetCategories(int companyId)
        {
            var cat = db.Categories.Where(c => c.CompanyId == companyId).ToList();
            cat.Add(new Category
            {
                CategoryId = 0,
                Description = "[Selecione uma Categoria]"
            });

            return cat = cat.OrderBy(c => c.Description).ToList();
        }


        public static List<Tax> GetTaxes(int companyId)
        {
            var tax = db.Taxes.Where(c => c.CompanyId == companyId).ToList();
            tax.Add(new Tax
            {
                TaxId = 0,
                Description = "[Selecione uma Taxa]"
            });

            return tax = tax.OrderBy(c => c.Description).ToList();
        }

        public static List<Customer> GetCustomer(int companyId)
        {
            var qry = (from cu in db.Customers
                       join cc in db.CompanyCustomers on cu.CustomerId equals cc.CustomerId
                       join co in db.Companies on cc.CompanyId equals co.CompanyId
                       where co.CompanyId == companyId
                       select new { cu }).ToList();

            var customer = new List<Customer>();
            foreach (var item in qry)
            {
                customer.Add(item.cu);
            }
            customer.Add(new Customer
            {
                CustomerId = 0,
                FirstName = "[ Selecione um Cliente ]"
            });

            return customer = customer.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
        }

        public static List<Provider> GetProvider(int companyId)
        {
            var qry = (from pr in db.Providers
                       join cp in db.CompanyProviders on pr.ProviderId equals cp.ProviderId
                       join co in db.Companies on cp.CompanyId equals co.CompanyId
                       where co.CompanyId == companyId
                       select new { pr }).ToList();

            var provider = new List<Provider>();
            foreach (var item in qry)
            {
                provider.Add(item.pr);
            }
            provider.Add(new Provider
            {
                ProviderId = 0,
                FirstName = "[ Selecione um Fornecedor ]"
            });

            return provider = provider.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
        }

        public static List<Product> GetProducts(int companyId, bool sw)
        {
            var products = db.Products.Where(p => p.CompanyId == companyId).ToList();
            return products.OrderBy(p => p.Description).ToList();
        }

        public static List<WareHouse> GetWareHouse(int companyId, bool sw)
        {
            var warehouse = db.WareHouses.Where(p => p.CompanyId == companyId).ToList();
            return warehouse.OrderBy(p => p.Name).ToList();
        }

        public static List<Product> GetProducts(int companyId)
        {

            var product = db.Products.Where(c => c.CompanyId == companyId).ToList();
            product.Add(new Product
            {
                ProductId = 0,
                Description = "[ Selecione um Produto ]"
            });

            return product = product.OrderBy(c => c.Description).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}