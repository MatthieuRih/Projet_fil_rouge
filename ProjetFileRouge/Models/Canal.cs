using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFileRouge.Models
{
    class Canal
    {
        private int id;
        private string theme;
        private string description;
        private DateTime dateCreation;
        private int actif;
        private int idUtilisateur;

        public int Id { get => id; set => id = value; }
        public string Theme { get => theme; set => theme = value; }
        public string Description { get => description; set => description = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public int Actif { get => actif; set => actif = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }

        public Canal()
        {
            DateCreation = DateTime.Now;
        }
    }
}
