using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter
{
    internal class DatabaseConstants
    {

         public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        // A name for the prototype database, can be replaced with an appropriate for the real application
        // or consolidated between modules to save costs
        public const string DatabaseFilename = "PatientCallCenter.db3";
    }
}
