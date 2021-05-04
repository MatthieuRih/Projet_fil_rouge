using ProjetFileRouge.DAO;
using System;
using System.Collections.Generic;

namespace ProjetFileRouge.Models
{
    class Admin : Utilisateur
    {
        private int administrateur;

        public Admin(string pseudo, string prenom, string nom, string email, string motDePasse, string avatar, int actif) : base(pseudo, prenom, nom, email, motDePasse, avatar, actif)
        {
            Administrateur = administrateur;
        }

        public int Administrateur { get => administrateur; set => administrateur = value; }


    }
}
