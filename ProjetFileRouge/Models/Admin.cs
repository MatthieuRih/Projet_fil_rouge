using ProjetFileRouge.DAO;
using System;
using System.Collections.Generic;

namespace ProjetFileRouge.Models
{
    class Admin : Utilisateur
    {
        private int administrateur;
        public int Administrateur { get => administrateur; set => administrateur = value; }


    }
}
