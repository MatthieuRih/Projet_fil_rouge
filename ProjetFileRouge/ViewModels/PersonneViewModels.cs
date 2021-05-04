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
    class PersonneViewModels : ViewModelBase
    {
        private Utilisateur personne;
        private string contentButton;
        public int Id { get => Personne.Id; set => Personne.Id = value; }

        public bool IsMr
        {
            get => Personne.IsMr;
            set
            {
                Personne.IsMr = value;
                RaisePropertyChanged("IsMr");
            }
        }

        public bool IsMme
        {
            get => Personne.IsMme;
            set
            {
                Personne.IsMme = value;
                RaisePropertyChanged("IsMme");

            }
        }

        public bool IsMlle
        {
            get => Personne.IsMlle;
            set
            {
                Personne.IsMlle = value;
                RaisePropertyChanged("IsMlle");
            }
        }

        public string Titre
        {
            get
            {
                if (IsMr)
                    return "Mr";
                else if (IsMme)
                    return "Mme";
                else if (IsMlle)
                    return "Mlle";
                else
                    return null;
            }
        }
        public string Prenom
        {
            get => Personne.Prenom;
            set
            {
                if (Tools.IsText(value))
                {
                    Personne.Prenom = value;
                    RaisePropertyChanged("Prenom");
                }
                else
                    throw new Exception();
            }
        }
        public string Nom
        {
            get => Personne.Nom;
            set
            {
                if (Tools.IsText(value))
                {
                    Personne.Nom = value;
                    RaisePropertyChanged("Nom");
                }
                else
                    throw new Exception();
            }
        }
        public string Email
        {
            get => Personne.Email;
            set
            {
                if (Tools.IsMail(value)) { 
                    Personne.Email = value;
                    RaisePropertyChanged("Email"); 
                }
                else
                    throw new Exception();
            }
        }
        public string Telephone
        {
            get => Personne.Telephone;
            set
            {
                if (Tools.IsTel(value))
                {
                    Personne.Telephone = value;
                    RaisePropertyChanged("Telephone");
                }
                else
                    throw new Exception();
            }
        }

        public ObservableCollection<Utilisateur> Personnes { get; set; }

        public Utilisateur Personne { get => personne; set 
            { 
                personne = value;

                if (personne != null)
                {
                    if (Personne.Titre == "Mr")
                    {
                        Personne.IsMr = true;
                        RaisePropertyChanged("IsMr");
                    }
                    else if (Personne.Titre == "Mme")
                    {
                        Personne.IsMme = true;
                        RaisePropertyChanged("IsMme");
                    }
                    else if (Personne.Titre == "Mlle")
                    {
                        Personne.IsMlle = true;
                        RaisePropertyChanged("IsMlle");
                    }
                    else
                    {
                        Personne.IsMr = false;
                        Personne.IsMme = false;
                        Personne.IsMlle = false;
                    }

                    RaisePropertyChanged("Nom");
                    RaisePropertyChanged("Prenom");
                    RaisePropertyChanged("Email");
                    RaisePropertyChanged("Telephone");
                    RaisePropertyChanged("ContentButton");
                }
            } 
        }

        public ICommand ValidCommand { get; set; }

        public string ContentButton { get => Personne.Id > 0 ? "Modifier" : "Ajouter"; }

        public PersonneViewModels()
        {
            Personne = new Utilisateur();
            ValidCommand = new RelayCommand(ActionValidCommand);
            Personnes = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
        }

        public void ActionValidCommand()
        {
            if (Personne.Id > 0)
            {
                Personne.Titre = Titre;

                if (Personne.Update())
                {
                    MessageBox.Show("Contact mis à jour avec l'id " + Personne.Id);
                    Personnes = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
                    RaisePropertyChanged("Personnes");
                    Personne = new Utilisateur();
                }
            }
            else
            {
                Personne.Titre = Titre;
                if (Personne.Add())
                {
                    MessageBox.Show("Contact ajouté avec l'id :" + Personne.Id);
                    Personnes.Add(Personne);
                    Personne = new Utilisateur();
                }
                else
                {
                    MessageBox.Show("Erreur d'ajout");
                }
            }
        }
    }
}
