using KwikMedicalResponseCenter.PatientCallCenter.Database.DataModels;
using Microsoft.Maui.Controls.Shapes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter.Database
{
    //This is entirely a test database, for non-demo system a server should be used
    //to host the database, rather than in-memory, however this class should be retrofitted with new database
    // to improve re-using of components (as all components in prototype use this DB)


    //To help with data availablity, security and separation the application will have its own database
    public class DB
        {
            public static SQLiteConnection connection;

            public DB()
            {
                this.Init();
            }

            // A method to create a DB to allow for unit tests
            // (In future ideally the connection would not be null to test error handling correctly)
            public DB(bool test)
            {
                connection = new SQLiteConnection("DataSource=:memory:");
            }

            //This will init the database with mockData
            //Disable the code in those resources if
            public void Init()
            {
                string databasePath = DatabaseConstants.DatabasePath;
                if (connection is not null)
                {
                    return;
                }
                connection = new SQLiteConnection(databasePath, DatabaseConstants.Flags);
               connection.CreateTable<Request>();
                //Enable to clean up the data in the tables
                //cleanup();
            }
            private void cleanup()
            {
            connection.DropTable<Request>();
            connection.Dispose();
            }
        }
    }

