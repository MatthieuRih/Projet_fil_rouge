using ProjetFileRouge.DAO;
using System;
using System.Collections.Generic;

namespace ProjetFileRouge.Models
{
    class Utilisateur
    {
        private int id;
        private string pseudo;
        private string nom;
        private string prenom;
        private string email;
        private DateTime dateCreation;
        private string motDePasse;
        private string avatar;
        private int actif; private int administrateur;

        public Utilisateur()
        {
            DateCreation = DateTime.Now;
        }

        public int Id { get => id; set => id = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public int Actif { get => actif; set => actif = value; }
        public int Administrateur { get => administrateur; set => administrateur = value; }

        public bool Add()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Create(this);
        }

        public bool Update()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Update(this);
        }

        public static List<Utilisateur> GetAll()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.FindAll();
        }
    }
}
