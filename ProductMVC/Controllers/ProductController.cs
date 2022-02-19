using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> pls = new List<Product>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDataBase;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdCreate = new SqlCommand();
            cmdCreate.Connection = cn;
            cmdCreate.CommandType = System.Data.CommandType.Text;
            cmdCreate.CommandText = "select * from Products";

            SqlDataReader dr = cmdCreate.ExecuteReader();
            while (dr.Read())
            {
                pls.Add(new Product { ProductId=dr.GetInt32(0), ProductName =dr.GetString(1), Rate =dr.GetDecimal(2), Description =dr.GetString(3), CategoryName =dr.GetString(4)});
            }
            cn.Close();
            return View(pls);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
         
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id=1)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDataBase;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = System.Data.CommandType.Text;
            cmdUpdate.CommandText = "select * from Products where ProductId=@ProductId";
            cmdUpdate.Parameters.AddWithValue("@ProductId",id);

            SqlDataReader dr = cmdUpdate.ExecuteReader();
            Product pls = null;
            while (dr.Read())
            {
                pls=new Product { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4)};
            }
            cn.Close();
            return View(pls);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Product p)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDataBase;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = System.Data.CommandType.Text;
            cmdUpdate.CommandText = "Update Products Set ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId=@ProductId";
            cmdUpdate.Parameters.AddWithValue("@ProductId", (Int32)p.ProductId);
            cmdUpdate.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmdUpdate.Parameters.AddWithValue("@Rate",p.Rate);
            cmdUpdate.Parameters.AddWithValue("@Description", p.Description);
            cmdUpdate.Parameters.AddWithValue("@CategoryName", p.CategoryName);
            try
            {
                cmdUpdate.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
