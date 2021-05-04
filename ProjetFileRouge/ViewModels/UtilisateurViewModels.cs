using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjetFileRouge.Classes;
using ProjetFileRouge.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ProjetFileRouge.ViewModels
{
    class UtilisateurViewModels : ViewModelBase
    {
        private Utilisateur utilisateur;
        private string contentButton;
        public int Id { get => Utilisateur.Id; set => Utilisateur.Id = value; }

        public DateTime DateCreation { get => Utilisateur.DateCreation; 
            set { 
                Utilisateur.DateCreation = value;
                RaisePropertyChanged("DateCreation");
            }
        }
        public string Avatar { get => Utilisateur.Avatar; 
            set { 
                Utilisateur.Avatar = value;
                RaisePropertyChanged("Avatar");
            } 
        }
        public int Actif { get => Utilisateur.Actif; 
            set { 
                Utilisateur.Actif = value;
                RaisePropertyChanged("Actif");
            } 
        }
        public int Administrateur { get => Utilisateur.Administrateur; 
            set {
                Utilisateur.Administrateur = value;
                RaisePropertyChanged("Administrateur");
            } 
        }

        public string Pseudo
        {
            get => Utilisateur.Pseudo;
            set
            {
                if (Tools.IsPseudo(value))
                {
                    Utilisateur.Pseudo = value;
                    RaisePropertyChanged("Pseudo");
                }
                else
                    throw new Exception();
            }
        }

        public string Prenom
        {
            get => Utilisateur.Prenom;
            set
            {
                if (Tools.IsText(value))
                {
                    Utilisateur.Prenom = value;
                    RaisePropertyChanged("Prenom");
                }
                else
                    throw new Exception();
            }
        }
        public string Nom
        {
            get => Utilisateur.Nom;
            set
            {
                if (Tools.IsText(value))
                {
                    Utilisateur.Nom = value;
                    RaisePropertyChanged("Nom");
                }
                else
                    throw new Exception();
            }
        }
        public string Email
        {
            get => Utilisateur.Email;
            set
            {
                if (Tools.IsMail(value)) { 
                    Utilisateur.Email = value;
                    RaisePropertyChanged("Email"); 
                }
                else
                    throw new Exception();
            }
        }
        public string MotDePasse
        {
            get => Utilisateur.MotDePasse;
            set
            {
                if (Tools.IsMdp(value))
                {
                    Utilisateur.MotDePasse = value;
                    RaisePropertyChanged("MotDePasse");
                }
                else
                    throw new Exception();
            }
        }

        public ObservableCollection<Utilisateur> Utilisateurs { get; set; }

        public Utilisateur Utilisateur { get => utilisateur; set 
            { 
                utilisateur = value;

                if (utilisateur != null)
                {
                    RaisePropertyChanged("Pseudo");
                    RaisePropertyChanged("Nom");
                    RaisePropertyChanged("Prenom");
                    RaisePropertyChanged("Email");
                    RaisePropertyChanged("MotDePasse");
                    RaisePropertyChanged("ContentButton");
                }
            } 
        }

        public ICommand ValidCommand { get; set; }

        public string ContentButton { get => Utilisateur.Id > 0 ? "Modifier" : "Ajouter"; }

        public UtilisateurViewModels()
        {
            Utilisateur = new Utilisateur();
            ValidCommand = new RelayCommand(ActionValidCommand);
            Utilisateurs = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
        }

        public void ActionValidCommand()
        {
            if (Utilisateur.Id > 0)
            {

                if (Utilisateur.Update())
                {
                    MessageBox.Show("Utilisateur mis à jour avec l'id " + Utilisateur.Id);
                    Utilisateurs = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
                    RaisePropertyChanged("Utilisateurs");
                    Utilisateur = new Utilisateur();
                }
            }
            else
            {
                if (Utilisateur.Add())
                {
                    MessageBox.Show("Utilisateur ajouté avec l'id :" + Utilisateur.Id);
                    Utilisateurs.Add(Utilisateur);
                    Utilisateur = new Utilisateur();
                }
                else
                {
                    MessageBox.Show("Erreur d'ajout");
                }
            }
        }
    }
}
