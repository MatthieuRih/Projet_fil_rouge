using System.Data.SqlClient;

namespace ProjetFileRouge.Data
{
    public class Bdd
    {
        static string chaine = @"Data Source=(Localdb)\Personne;Integrated Security=True; Connect Timeout=30";
        public static SqlConnection Cnx { get => new SqlConnection(chaine); }

    }
}
