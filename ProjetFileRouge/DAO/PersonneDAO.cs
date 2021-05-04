using ProjetFileRouge.Models;
using ProjetFileRouge.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetFileRouge.DAO
{
    class PersonneDAO : AbstractDAO<Utilisateur>
    {
        public override bool Create(Utilisateur element)
        {
            request = "INSERT INTO PERSONNE (titre, nom, prenom, email, telephone) OUTPUT INSERTED.ID VALUES (@titre, @nom, @prenom, @email, @telephone)";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", element.Titre));
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@email", element.Email));
            command.Parameters.Add(new SqlParameter("@telephone", element.Telephone));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public override bool Delete(Utilisateur element)
        {
            throw new NotImplementedException();
        }

        public override Utilisateur Find(int index)
        {
            throw new NotImplementedException();
        }

        public override List<Utilisateur> Find(Func<Utilisateur, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public override List<Utilisateur> FindAll()
        {
            List<Utilisateur> personnes = new List<Utilisateur>();
            request = "SELECT * FROM PERSONNE ORDER BY nom ASC";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Utilisateur c = new Utilisateur
                {
                    Id = reader.GetInt32(0),
                    Titre = reader.GetString(1),
                    Nom = reader.GetString(2),
                    Prenom = reader.GetString(3),
                    Email = reader.GetString(4),
                    Telephone = reader.GetString(5)
                };
                personnes.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return personnes;
        }

        public override bool Update(Utilisateur element)
        {
            request = "UPDATE PERSONNE set Titre = @titre, Nom = @nom, Prenom = @prenom, Email = @email, Telephone = @telephone where id=@id";
            connection = Bdd.Cnx;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", element.Titre));
            command.Parameters.Add(new SqlParameter("@nom", element.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", element.Prenom));
            command.Parameters.Add(new SqlParameter("@email", element.Email));
            command.Parameters.Add(new SqlParameter("@telephone", element.Telephone));
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
