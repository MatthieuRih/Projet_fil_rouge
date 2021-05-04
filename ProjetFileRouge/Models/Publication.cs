using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFileRouge.Models
{
    class Publication
    {
        private int id;
        private DateTime dateCreation;
        private int idCanal;
        private int idUtilisateur;
        private int actif;

        public int Id { get => id; set => id = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public int IdCanal { get => idCanal; set => idCanal = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        public int Actif { get => actif; set => actif = value; }

        public Publication()
        {
            DateCreation = DateTime.Now;
        }
    }
}
