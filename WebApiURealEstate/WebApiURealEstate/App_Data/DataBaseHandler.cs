using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using WebApiURealEstate.Models;

namespace WebApiURealEstate.App_Data
{
    public class DataBaseHandler
    {
        static private DBConnection DBConnection;
        string path = @"URealEstateLog.txt";

        public DataBaseHandler()
        {
            DBConnection = DBConnection.Instance();
            DBConnection.DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
            DBConnection.Password = ConfigurationManager.AppSettings["Password"];
            DBConnection.Server = ConfigurationManager.AppSettings["Server"];
            DBConnection.User = ConfigurationManager.AppSettings["User"];


            DBConnection.Start();
        }

        public void EndDBConnection()
        {
            DBConnection.Close();
        }

        public void InsertUser(CreateUserRequest user)
        {
            DateTime? lastModified = DateTime.Now;

            //string query = String.Format("INSERT INTO users (id, name, rooms, location, email, price, typeId, saved, disliked) " +
            //    "Values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
            //    user.id, user.name, user.rooms, user.location, user.email, user.price, user.typeId, user.saved, user.disliked);

            string query = String.Format(@"INSERT INTO users (name, email, password, location, rooms, price)
                Values('{0}', '{1}', '{2}', '{3}', {4}, {5})",
                user.name, user.email, user.password, user.location, user.rooms, user.price);

            MySqlCommand command = new MySqlCommand(query, DBConnection.Connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //File.AppendAllText(path, "Server DB Error at RunQuery function" + ex.Message + Environment.NewLine);
            }
        }

        public List<string> GetLocations()
        {
            List<string> locations = new List<string> ();
            try
            {
                    string query = "SELECT location FROM assets";
                    var cmd = new MySqlCommand(query, DBConnection.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        locations.Add(reader.GetString(0));
                    }
                    reader.Close();
            }
            catch (Exception ex)
            {
                //File.AppendAllText(path, "Server DB Error at GetLocations function" + ex.Message + Environment.NewLine);
            }
            return locations;
        }

        #region guessTheSongFunctions
        public void SaveUserData(string firstName, string lastName, DateTime? dateOfBirth, int genreID, int artistID)
        {
            int score = 0;
            DateTime? lastModified = DateTime.Now;
            string query = "INSERT INTO users (FirstName, LastName, DateOfBirth, Genre, Artist, Score, LastModified)" +
                " Values(@firstName, @lastName, @dateOfBirth, @genre, @artist, @score, @lastModified)";

            MySqlCommand command = new MySqlCommand(query, DBConnection.Connection);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@genre", genreID);
            command.Parameters.AddWithValue("@artist", artistID);
            command.Parameters.AddWithValue("@score", score);
            command.Parameters.AddWithValue("@lastModified", lastModified);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                File.AppendAllText(path, "Server DB Error at RunQuery function" + ex.Message + Environment.NewLine);
            }
        }

        public void SaveUserScore(int score)
        {
            string query;
            int id = 1;
            try
            {
                if (DBConnection.IsConnect())
                {
                    //check the user id:
                    query = "SELECT users.id FROM team12.users WHERE users.LastModified in " +
                            "(SELECT max(users.LastModified) FROM users)";
                    var cmd = new MySqlCommand(query, DBConnection.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Int32.Parse(reader.GetString(0));
                    }
                    reader.Close();

                    //update user's score:
                    query = "UPDATE team12.users SET users.Score = @score " +
                            "WHERE users.id = @id";
                    MySqlCommand command = new MySqlCommand(query, DBConnection.Connection);
                    command.Parameters.AddWithValue("@score", score);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(path, "Server DB Error at SaveUserScore function" + ex.Message + Environment.NewLine);
            }
        }

        public string GetArtistById(int artistId)
        {
            string res = "";
            try
            {
                if (DBConnection.IsConnect())
                {
                    string query = "SELECT t.artist FROM artists t WHERE t.id = " + artistId;
                    var cmd = new MySqlCommand(query, DBConnection.Connection);
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    res = reader.GetString(0);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(path, "Server DB Error at GetArtistById function" + ex.Message + Environment.NewLine);
            }
            return res;
        }
        #endregion
    }
}
