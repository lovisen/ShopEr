using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Common;


/// <summary>
/// Summary description for DataAccess
/// </summary>
public static class DataAccess
{
    // executes a command and returns the results as a DataTable object
    public static DataTable ExecuteSelectCommand(DbCommand command)
    {
        //dimmar en Datatable som ska heta table
        DataTable table;
        try
        {
            //open the connection
            command.Connection.Open();
            //execute the command and save the result in the table
            DbDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);

            //close
            reader.Close();
        }
        finally
        {
            command.Connection.Close();

        }
        return table;
    }
    public static DbCommand CreateCommand()
    {

        //hämta databas namnet
        string dataProviderName = ShopErConfiguration.DbProviderName;

        //hämta connectionstring
        string connnectionString = ShopErConfiguration.DbConnectionString;

        //göra en ny data provider factory
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);

        //hämta databas conn object
        DbConnection conn = factory.CreateConnection();
        //sätta conn string
        conn.ConnectionString = connnectionString;
        //gör databas spec comm obj
        DbCommand comm = conn.CreateCommand();
        //set the command type to stored procedure
        comm.CommandType = CommandType.StoredProcedure;
        //returns the command object
        return comm;

    }
    //Ytterligare en metod dom heter CreateCommand, men som tar emot en parameter
    public static DbCommand CreateCommand(string commandName)
    {
        var comm = CreateCommand();
        comm.CommandText = commandName;
        return comm;
    }

    //skapar och konfigurera en generell dataparameter med värden för namn, värde och typ. Denna metod 
    //är onödig iom att metoden CreateAndAddParameter kommer nedan
    public static DbParameter CreateParameters(DbCommand comm, string paramName, object value, DbType dataBaseType)
    {
        //skapa parameter
        var p = comm.CreateParameter();
        // konfigurera
        p.ParameterName = paramName;
        p.Value = value;
        p.DbType = dataBaseType;
        return p;
    }

    //Utökad DbCommand så man kan skapa och lägga till en parameter på samma gång.
    public static void CreateAndAddParameter(this DbCommand comm, string paramName, object value, DbType dataBaseType)
    {
        //skapa parameter
        var p = comm.CreateParameter();
        // konfigurera
        p.ParameterName = paramName;
        p.Value = value;
        p.DbType = dataBaseType;
        comm.Parameters.Add(p);

    }
    public static void CreateAndAddParameter(this DbCommand comm, string paramName, object value, DbType dataBaseType, int size)
    {
        comm.CreateAndAddParameter(paramName, value, dataBaseType);
        comm.Parameters[paramName].Size = size;

    }
    public static void CreateAndAddParameter(this DbCommand comm, string paramName, object value, DbType dataBaseType, ParameterDirection direction)
    {
        comm.CreateAndAddParameter(paramName, value, dataBaseType);
        comm.Parameters[paramName].Direction = direction;

    }

    //Update, delete eller insert commandeon med en nonquery, retunerar antal rader som blivit ändrade
    public static int ExecuteNonQuery(DbCommand command)
    {
        int affectedRows = -1;
        //kör command och stäng på slutet
        try
        {
            //öppna
            command.Connection.Open();
            //kör kommandot och hämta antalet rader
            affectedRows = command.ExecuteNonQuery();

        }
        catch (Exception)
        {
            //Logga
            throw;
        }
        finally
        {
            //stäng connection
            command.Connection.Close();
        }
        //returnera raderna
        return affectedRows;
    }
    //Scalar, returnerar ett ända resultat som sträng
    public static string ExecuteScalar(DbCommand command)
    {
        //värdet som ska returneras
        string value = "";
        try
        {
            command.Connection.Open();
            value = command.ExecuteScalar().ToString();
        }
        catch (Exception)
        {
            //Logga fel
            throw;
        }
        finally
        {
            command.Connection.Close();
        }
        return value;
    }

}
