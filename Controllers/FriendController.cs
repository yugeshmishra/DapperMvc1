using DapperMvc1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace DapperMvc1.Controllers
{
    public class FriendController : Controller
    {
       

        // GET: Friend
        public ActionResult Index()
        {
            List<Friend> FriendList = new List<Friend>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString)) 
            {
                FriendList = db.Query<Friend>("Select * From Friends").ToList();
            }
            return View(FriendList);
        }

        // GET: Friend/Details/5
        public ActionResult Details(int id)
        {
            Friend _friend = new Friend();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {
                _friend = db.Query<Friend>("Select * From Friends " +
                                       "WHERE ID =" + id, new { id }).SingleOrDefault();
            }
            return View(_friend);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        public ActionResult Create(Friend _friend)
        {
            try
            {
                // TODO: Add insert logic here
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
                {

                    string sqlQuery = "Insert Into Friends (Name,City,PhoneNumber) Values(" + _friend.Name + "," + _friend.City + "," + _friend.PhoneNumber + ")";

                    int rowsAffected = db.Execute(sqlQuery);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int id)
        {
            Friend _friend = new Friend();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {
                _friend = db.Query<Friend>("Select * From Friends " +
                                       "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return View(_friend);
        }

        // POST: Friend/Edit/5
        [HttpPost]
        public ActionResult Edit(Friend _friend)
        {
            try
            {
                // TODO: Add update logic here
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
                {

                    string sqlQuery = "update Friends set Name= " + _friend.Name + ",City=" + _friend.City + "',PhoneNumber='" + _friend.PhoneNumber + "' where Id=" + _friend.Id;

                    int rowsAffected = db.Execute(sqlQuery);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int id)
        {
            Friend _friend = new Friend();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {
                _friend = db.Query<Friend>("Select * From Friends " +
                                       "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return View(_friend);
        }

        // POST: Friend/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
                {
                    string sqlQuery = "Delete From Friends WHERE Id = " + id;

                    int rowsAffected = db.Execute(sqlQuery);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
