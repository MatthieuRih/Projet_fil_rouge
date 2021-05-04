using ProjetFileRouge.DAO;
using System.Collections.Generic;

namespace ProjetFileRouge.Models
{
    class Personne
    {
        private int id;
        private string titre;
        private string prenom;
        private string nom;
        private string email;
        private string telephone;
        private bool isMr;
        private bool isMme;
        private bool isMlle;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Email { get => email; set => email = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public bool IsMr { get => isMr; set => isMr = value; }
        public bool IsMme { get => isMme; set => isMme = value; }
        public bool IsMlle { get => isMlle; set => isMlle = value; }

        public bool Add()
        {
            AbstractDAO<Personne> dao = new PersonneDAO();
            return dao.Create(this);
        }

        public bool Update()
        {
            AbstractDAO<Personne> dao = new PersonneDAO();
            return dao.Update(this);
        }

        public static List<Personne> GetAll()
        {
            AbstractDAO<Personne> dao = new PersonneDAO();
            return dao.FindAll();
        }
    }
}
