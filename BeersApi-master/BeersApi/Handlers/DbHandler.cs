using System.Collections.Generic;
using System.Data.SqlClient;
using BeersLib;

namespace BeersApi.Handlers
{
    public class DbHandler
    {
        static string connectionString = "workstation id=swinburneswd.mssql.somee.com;packet size=4096;user id=swinburne_swd;pwd=TQ,wGzw@9\"}'=[Dm;data source=swinburneswd.mssql.somee.com;persist security info=False;initial catalog=swinburneswd";
        SqlConnection connection;

        public string Connect() {
            connection = new SqlConnection(connectionString);
            connection.Open();

            return "Ok";

        }

        public List<Beer> GetAllBeers() {
            
            List<Beer> beers = new List<Beer>();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
            
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Beer", connection);
                
                SqlDataReader result = command.ExecuteReader();
                
                // result of command.ExecuteReader is an object that can only be traversed one way
                while (result.Read())
                {
                    // convert the data from DB into the object neeeded
                    string name = result.GetString(0);
                    string brewery = result.GetString(1);
                    float abv = (float)result.GetDecimal(2);
                    uint ibu = (uint)result.GetInt32(3);
                    int amount = result.GetInt32(4);
                    float cost = (float)result.GetDecimal(5);

                    beers.Add(new Beer(name, brewery, abv, ibu, amount, cost));

                }
            }
            
            return beers;
        }

        public Beer GetBeerByName(string name) {
            string query = "SELECT * FROM Beer WHERE Name = @Name"; 
            
            Beer foundBeer = null;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);

                // SqlParameter is used to protect against SQL Injection
                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@Name";
                nameParam.Value = name;

                command.Parameters.Add(nameParam);

                connection.Open();
                SqlDataReader result = command.ExecuteReader();

                // result of command.ExecuteReader is an object that can only be traversed one way
                while (result.Read())
                {
                    // convert the data from DB into the object neeeded
                    string beerName = result.GetString(0);
                    string brewery = result.GetString(1);
                    float abv = (float)result.GetDecimal(2);
                    uint ibu = (uint)result.GetInt32(3);
                    int amount = result.GetInt32(4);
                    float cost = (float)result.GetDecimal(5);

                    foundBeer = new Beer(beerName, brewery, abv, ibu, amount, cost);
                }
            
            }

            return foundBeer;

        }

        public int addNewBeer(Beer newBeer) {
            // TODO:  Code to insert newBeer into the DB goes here.
            // Remember to parameterise you query.
            // inserting into the db won't command.ExecuteReader().  A different method is used:  Google it.
            int rowsAffected;

            string query = "INSERT INTO Beer VALUES (@name, @brewery, @abv, @ibu, @amount, @cost, @opened)";

            using(SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                 
                // SqlParameter is used to protect against SQL Injection
                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@name";
                nameParam.Value = newBeer.Name;

                SqlParameter breweryParam = new SqlParameter();
                breweryParam.ParameterName = "@brewery";
                breweryParam.Value = newBeer.Brewery;

                SqlParameter abvParam = new SqlParameter();
                abvParam.ParameterName = "@abv";
                abvParam.Value = newBeer.Abv;

                SqlParameter ibuParam = new SqlParameter();
                ibuParam.ParameterName = "@ibu";
                ibuParam.Value = (int)newBeer.Ibu;

                SqlParameter amountParam = new SqlParameter();
                amountParam.ParameterName = "@amount";
                amountParam.Value = newBeer.Amount;

                SqlParameter costParam = new SqlParameter();
                costParam.ParameterName = "@cost";
                costParam.Value = newBeer.Cost;

                SqlParameter openedParam = new SqlParameter();
                openedParam.ParameterName = "@opened";
                openedParam.Value = newBeer.Open;

                command.Parameters.Add(nameParam);
                command.Parameters.Add(breweryParam);
                command.Parameters.Add(abvParam);
                command.Parameters.Add(ibuParam);
                command.Parameters.Add(amountParam);
                command.Parameters.Add(costParam);
                command.Parameters.Add(openedParam);

                // ExecuteNonQuery does not return an SQL Result.  Insert, Delete and Update apply.
                rowsAffected = command.ExecuteNonQuery();

            }

            return rowsAffected;
        }
    }

}

