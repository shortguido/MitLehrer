using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// wichtig: es sollte immer gegen eine Schnittstelle (interface, basisklasse) programmiert werden
// --> Programm ist leichter wartbar, änderbar, testbar
namespace FirstWebApp.Models.DB {
    interface RepositoryUserDB {

        Task ConnectAsync();
        Task DisconnectAsync();

        //CRUD_Operationen ... Create Read Update Delete
        bool Insert(User user);
        bool Delete(int userId);
        bool Update(int userId, User newUserData);
        User GetUser(int userId);
        Task<List<User>> GetAllUsersAsync();
        bool Login(string Username, string Password);

        //weitere Methoden...



    }
}
