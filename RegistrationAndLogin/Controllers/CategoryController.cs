using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using RegistrationAndLogin.Models;

namespace RegistrationAndLogin.Controllers
{
    public class CategoryController : Controller
    {
        string connectionString = @"Data Source =LAPTOP-BQEQ6GDH\SQLEXPRESS;Initial Catalog= FlavaSolutionsGymnMVC; Integrated Security = True";
        //Category/Index
        [HttpGet]
         public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))

            {
                con.Open();
                String query = "SELECT * from categories";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
            }
            return View(dt);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View(new category());
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(category category)
        {
            using (SqlConnection con = new SqlConnection(connectionString))

            {
                con.Open();
                String query = "INSERT into categories Values (@title, @description, @dateAdded, @addedBy)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@title", category.title);
                cmd.Parameters.AddWithValue("@description", category.description);
                cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@addedBy", category.addedBy);

                cmd.ExecuteNonQuery();
            }

                return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            category category = new category();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * from categories where id = @id";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
            }
            if(dt.Rows.Count ==1)
            {
                category.id = Convert.ToInt32(dt.Rows[0][0].ToString());
                category.title =dt.Rows[0][1].ToString();
                category.description = dt.Rows[0][2].ToString();
                //category.dateAdded = Convert.ToDateTime(dt.Rows[0][3]);
                category.addedBy = Convert.ToInt32(dt.Rows[0][4].ToString());

                return View(category);
            }
            else
            return RedirectToAction("Index");
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(category category)
        {
            using (SqlConnection con = new SqlConnection(connectionString))

            {
                con.Open();
                String query = "UPDATE categories SET title = @title, description = @description, dateAdded = @dateAdded, addedBy = @addedBy where @id = id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", category.id);
                cmd.Parameters.AddWithValue("@title", category.title);
                cmd.Parameters.AddWithValue("@description", category.description);
                cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@addedBy", category.addedBy);

                cmd.ExecuteNonQuery();
            }
        
            return RedirectToAction("Index");
        }

            // GET: Category/Delete/5
            public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                String query = "DELETE from categories where @id = id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                String query = "DELETE from categories where @id = id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");

        }
    }
}
