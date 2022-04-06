using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;


//diese Klasse implementiert unser Interface 
namespace FirstWebApp.Models.DB {

    //paralelle bzw. asynchrone Programmierung 
    //Threads: sollten in C# nicht direkt verwendet werden
    //Tasks: sollten statt Threads verwendet werden
    //ansyc und await verwendet Tasks und vereinfacht die Programmierung mit Threads/Tasks
    //synchroner code und asynchroner Code sehen dadurch fast identisch aus
    //Regel: dauert eine Methode länger als ca 60ms dann sollte sie asynchron programmiert werden
    
    public class RepositoryUsersDB : RepositoryUserDB {

        //Verbindungszeichenkette enthält Server-ip-Adresse, Datenbankname, User+Passwort am DB Server
        private string connectionString = "Server=localhost;database=web_4b_g1;user=root;password=";
        //über diese Verbindung wird mit dem DB-Server kommuniziert
        //also SQL Befehle gesendet usw
        private DbConnection connection;
        public async Task ConnectAsync() {
            //falls die Verbindung noch nicht erzeugt wurde wird sie erzeugt
            if (this.connection == null)
            {
                this.connection = new MySqlConnection(this.connectionString);
            }
            //falls die Verbindung noch nicht geöffnet ist wird sie geöffnet
            if(this.connection.State != ConnectionState.Open)
            {
                //await wartet bis die Methode fertig ausgeführt wurde
                await this.connection.OpenAsync();
            }
        }

        public bool Delete(int userId) {
            if (this.connection?.State == ConnectionState.Open)
            {
                DbCommand cmdDelete = this.connection.CreateCommand();
                cmdDelete.CommandText = "delete from users where User_id = @User_id";

                DbParameter paramD = cmdDelete.CreateParameter();
                //hier den oben gewählten Parameternamen verwenden
                paramD.ParameterName = "User_id";
                paramD.DbType = DbType.Int32;
                paramD.Value = userId;

            return cmdDelete.ExecuteNonQuery() == 1;


            }
            return false;
        }

        public async Task DisconnectAsync() {
            //falls die Verbindung existiert und geöffnet ist 
            if ((this.connection != null) && (this.connection.State == ConnectionState.Open))
            {
                //wird sie geschlossen
               await this.connection.CloseAsync();
            }
        }

        public async Task<List<User>> GetAllUsersAsync() {

            List<User> users = new List<User>();

            if (this.connection?.State == ConnectionState.Open)
            {
                //leeres Command erzeugen
                DbCommand cmdAllusers = this.connection.CreateCommand();
                //SQL Befehl angeben
                cmdAllusers.CommandText = "select * from users;";


                //wir bekommen nun eine komplette Tabelle zurück, diese wird mit einem DbDataReader
                //Zeile für Zeile durchlaufen

                using (DbDataReader reader=await cmdAllusers.ExecuteReaderAsync() ) {
                    //mit read wird jeweils eine einzige Zeile (Datensatz) gelesen
                    while (await reader.ReadAsync())
                    {
                        //den User in der Liste abspeichern
                        users.Add(new User()
                        {
                            UserId = Convert.ToInt32(reader["User_id"]),
                            Username = Convert.ToString(reader["Username"]),
                            Password = Convert.ToString(reader["Password"]),
                            Birthdate = Convert.ToDateTime(reader["Birthdate"]),
                            Email = Convert.ToString(reader["Email"]),
                            Gender = (Gender)Convert.ToInt32(reader["Gender"])
                            
                        }) ;
                    
                    
                    }
                }//using   hier wird automatisch der Dbdatareader freigegeben
                //entspricht dem finally
            }

            //2 Fälle: es wird entweder eine leere Liste oder die Liste mit allen Usern zurückgeliefert
            return users;

        }

        public User GetUser(int userId) {
            User user;
            if (this.connection?.State == ConnectionState.Open)
            {
                DbCommand cmdGetUser = this.connection.CreateCommand();
                //SQL - Befehl angeben
                cmdGetUser.CommandText = "select * from users where User_id=@User_id";
                DbParameter paramID = cmdGetUser.CreateParameter();
                //hier den oben gewählten Parameternamen verwenden
                paramID.ParameterName = "User_id";
                paramID.DbType = DbType.String;
                paramID.Value = userId;
                using (DbDataReader reader = cmdGetUser.ExecuteReader())
                {
                    user = new User
                    {
                        UserId = Convert.ToInt32(reader["User_id"]),
                        Username = Convert.ToString(reader["username"]),
                        Password = Convert.ToString(reader["password"]),
                        Birthdate = Convert.ToDateTime(reader["birthdate"]),
                        Email = Convert.ToString(reader["email"]),
                        Gender = (Gender)Convert.ToInt32(reader["gender"])
                    };

                    return user;
                }

            }

            return null;

            // bitte keine Schleife verwenden

        }

        public bool Insert(User user) {
            if (this.connection?.State == ConnectionState.Open)
            {
                //ein leeres Command erzeugen
                DbCommand cmdInsert = this.connection.CreateCommand();
                //SQL Befehl angeben und parameter verwenden um sql injection zu vermeinden
                //@username ... Parametername (kann frei gewählt werden)
                //SQL-Injection: es versucht ein Angreifer einen SQL-Befehl an den Mysql-Server zu senden
                cmdInsert.CommandText = "insert into users values(null, @username, sha2(@password, 512),@mail, @bdate, @gender);";

                //Parameter @username befüllen
                //leeres Parameterobjekt hinzufügen
                DbParameter paramU = cmdInsert.CreateParameter();
                //hier den oben gewählten Parameternamen verwenden
                paramU.ParameterName = "username";
                paramU.DbType = DbType.String;
                paramU.Value = user.Username;

                DbParameter paramP = cmdInsert.CreateParameter();
                paramP.ParameterName = "password";
                paramP.DbType = DbType.String;
                paramP.Value = user.Password;

                DbParameter paramE = cmdInsert.CreateParameter();
                paramE.ParameterName = "mail";
                paramE.DbType = DbType.String;
                paramE.Value = user.Email;

                DbParameter paramBD = cmdInsert.CreateParameter();
                paramBD.ParameterName = "bdate";
                paramBD.DbType = DbType.DateTime;
                paramBD.Value = user.Birthdate;

                DbParameter paramG = cmdInsert.CreateParameter();
                paramG.ParameterName = "gender";
                paramG.DbType = DbType.Int32;
                paramG.Value = user.Gender;

                //Parameter mit unserem Command Insert verbinden
                cmdInsert.Parameters.Add(paramU);
                cmdInsert.Parameters.Add(paramP);
                cmdInsert.Parameters.Add(paramE);
                cmdInsert.Parameters.Add(paramBD);
                cmdInsert.Parameters.Add(paramG);

                //nun senden wir das Command (insert) an den Server
                return cmdInsert.ExecuteNonQuery() == 1;

            }

            return false;
        }

        public bool Login(string Username, string Password) {

            string pw;
            if (this.connection?.State == ConnectionState.Open)
            {
                //ein leeres Commmand erzuegen
                DbCommand cmdLogin = this.connection.CreateCommand();
                // SQL-Befehl angeben: Parameter verwenden, um SQL-Injection zu vermeiden
                //      @username... Paramtername - kann frei gewählt werden
                //       SQL-Injection: es versucht ein Angreifer einen SQL-Befehl zu den MySQL-Server zu senden
                cmdLogin.CommandText = "select password from users where username=@username; ";
                DbParameter paramUsername = cmdLogin.CreateParameter();
                //Parameter @username befüllen
                paramUsername.ParameterName = "username";
                paramUsername.DbType = DbType.String;
                paramUsername.Value = Username;
                using (DbDataReader reader = cmdLogin.ExecuteReader())
                {
                    pw = Convert.ToString(reader["password"]);
                };
                if (pw == Password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Update(int userId, User newUserData) {
            throw new NotImplementedException();
        }
    }
     
}
