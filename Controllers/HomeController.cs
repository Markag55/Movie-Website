using CapProj_Updated_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CapProj_Updated_.Controllers
{


    public class HomeController : Controller
    {
        //SqlCommand com = new SqlCommand();
        //SqlDataReader dr;
        //SqlConnection con = new SqlConnection();

        //private readonly ILogger<HomeController> _logger;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //    con.ConnectionString = CapProj_Updated_.Properties.Resources.ConnectionString;
        //}
        //public void FetchData()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mark\Source\Repos\Capstone\Data\Movies.mdb; User=Admin;Password=");
        //    if (movies.Count > 0)
        //    {
        //        movies.Clear();
        //    }
        //    try
        //    {
        //        con.Open();
        //        com.Connection = con;
        //        com.CommandText = "SELECT TOP (1000) [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[Movies].[dbo].[titleBasics] Where [genres] like '%Animation%'";
        //        dr = com.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //private TitleContext context { get; set; }

        //public HomeController(TitleContext ctx)
        //{
        //    context = ctx;
        //}
        public List<titleBasics> movies = new List<titleBasics>();
        public List<titleBasics> recomended = new List<titleBasics>();
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Movies.mdb";
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Animation(string sort)
        {
            //var movies = context.titleBasics.Where(m => m.genres == "Animation").ToList();
            //FetchData();
            if (movies.Count > 0)
            {
                movies.Clear();
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                if (sort == null)
                {
                    sort = "[primaryTitle]";
                }
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 1000 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [genres] like '%Animation%' and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by" + sort, connection);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
                }
            }
            return View(movies);

        }
        [HttpPost]
        public IActionResult Animation()
        {
            //var movies = context.titleBasics.Where(m => m.genres == "Animation").ToList();
            //FetchData();
            if (movies.Count > 0)
            {
                movies.Clear();
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 1000 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [genres] like '%Animation%' and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by [primaryTitle]", connection);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
                }
            }
            return View(movies);

        }
        public IActionResult Comedy(string sort)
        {
            if (movies.Count > 0)
            {
                movies.Clear();
            }
            if (sort == null)
            {
                sort = "[primaryTitle]";
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 1000 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [genres] like '%Comedy%' and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by" + sort, connection);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
                }
            }
            return View(movies);
        }

        public IActionResult Drama(string sort)
        {
            if (movies.Count > 0)
            {
                movies.Clear();
            }
            if (sort == null)
            {
                sort = "[primaryTitle]";
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 1000 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [genres] like '%Drama%' and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by" + sort, connection);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
                }
            }
            return View(movies);
        }

        struct Movie
        {
            List<titleBasics> movies, recomended;
            public Movie(List<titleBasics> movies, List<titleBasics> recomended)
            {
                this.movies = movies;
                this.recomended = recomended;
            }
        }



        [HttpGet]
        public IActionResult InformationTemplate(string primarytitle, string genres)
        {

            if (movies.Count > 0)
            {
                movies.Clear();
            }
            
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [primaryTitle] like" + "'" + primarytitle + "'", connection);
                dr = command.ExecuteReader();
                dr.Read();
                movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
    
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader d = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 4 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [genres] like '%" + genres + "%' and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by [primaryTitle]", connection);
                d = command.ExecuteReader();
                while (d.Read())
                {
                    recomended.Add(new titleBasics() { tconst = d["tconst"].ToString(), titleType = d["titleType"].ToString(), primaryTitle = d["primaryTitle"].ToString(), originalTitle = d["originalTitle"].ToString(), isAdult = float.Parse(d["isAdult"].ToString()), startYear = float.Parse(d["startYear"].ToString()), endYear = d["endYear"].ToString(), genres = d["genres"].ToString() });
                }
            }
            var viewModel = new titleBasics
            {
                movie = movies,
                recomend = recomended
            };
            return View(viewModel);
        }
        public IActionResult Horror(string sort)
        {
            if (movies.Count > 0)
            {
                movies.Clear();
            }
            if (sort == null)
            {
                sort = "[primaryTitle]";
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 1000 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [genres] like '%Horror%' and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by" + sort, connection);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
                }
            }
            return View(movies);
        }

        public IActionResult Romance(string sort)
        {
            if (movies.Count > 0)
            {
                movies.Clear();
            }
            if (sort == null)
            {
                sort = "[primaryTitle]";
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 1000 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [genres] like '%Romance%' and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by" + sort, connection);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
                }
            }
            return View(movies);
        }

        public IActionResult SciFi(string sort)
        {
            if (movies.Count > 0)
            {
                movies.Clear();
            }
            if (sort == null)
            {
                sort = "[primaryTitle]";
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 1000 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [genres] like '%Sci-Fi%' and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by" + sort, connection);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
                }
            }
            return View(movies);
        }


        public IActionResult Search(string title)
        {
            if (movies.Count > 0)
            {
                movies.Clear();
            }
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                OleDbDataReader dr = null;
                OleDbCommand command = new OleDbCommand("SELECT TOP 1000 [tconst],[titleType],[primaryTitle],[originalTitle],[isAdult],[startYear],[endYear],[genres]FROM[titleBasics] Where [primaryTitle] like" + "'%" + title + "%'" +  "and [titleType] like 'Movie' and ([startYear] like '%1%' or [startYear] like '%2%') and [isAdult] like '0' order by primaryTitle", connection);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    movies.Add(new titleBasics() { tconst = dr["tconst"].ToString(), titleType = dr["titleType"].ToString(), primaryTitle = dr["primaryTitle"].ToString(), originalTitle = dr["originalTitle"].ToString(), isAdult = float.Parse(dr["isAdult"].ToString()), startYear = float.Parse(dr["startYear"].ToString()), endYear = dr["endYear"].ToString(), genres = dr["genres"].ToString() });
                }
            }
            return View(movies);
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}
