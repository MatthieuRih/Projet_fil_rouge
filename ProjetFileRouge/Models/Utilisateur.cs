﻿using ProjetFileRouge.DAO;
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
        private int actif;

        public Utilisateur(string pseudo, string prenom, string nom, string email, string motDePasse, string avatar, int actif)
        {
            Pseudo = pseudo;
            Prenom = prenom;
            Nom = nom;
            Email = email;
            DateCreation = DateTime.Now;
            MotDePasse = motDePasse;
            Avatar = avatar;
            Actif = actif;
        }

        public int Id { get => id; set => id = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Email { get => email; set => email = value; }
        public Timestamp DateCreation { get => dateCreation; set => dateCreation = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public int Actif { get => actif; set => actif = value; }

        public bool Add()
        {
            AbstractDAO<Utilisateur> dao = new PersonneDAO();
            return dao.Create(this);
        }

        public bool Update()
        {
            AbstractDAO<Utilisateur> dao = new PersonneDAO();
            return dao.Update(this);
        }

        public static List<Utilisateur> GetAll()
        {
            AbstractDAO<Utilisateur> dao = new PersonneDAO();
            return dao.FindAll();
        }
    }
}
